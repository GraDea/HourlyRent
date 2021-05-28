using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using HourlyRate.Data;
using HourlyRate.Data.Models;
using HourlyRate.Models;
using HourlyRate.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HourlyRate.Controllers
{
    public partial class OwnerController : Controller
    {
        private readonly MainDbContext context;
        public string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=hourlyrentphotos;AccountKey=v7UBtaQSmDxQRFBY50MmOSsRL6bJgPhqpC2TQ7vx68TaigXYFvQ0+yl+Eblav28gcq0Veo2wKP0x8RVlSPu/5A==;EndpointSuffix=core.windows.net";

        public OwnerController(MainDbContext context)
        {
            this.context = context;
        }

        public IActionResult Objects()
        {
            var realtyObjects = context
                .Objects
                .Include(x => x.Images)
                .Select(o => Map(o)).ToArray();
            
            return View(realtyObjects);
        }

        [HttpGet]
        public IActionResult New()
        {
            var realEstateObject = new RealEstateObject();
            return View(realEstateObject);
        }

        [HttpPost]
        public IActionResult New(RealEstateObject realEstateObject)
        {
            var realObject = context.Objects.Add(Map(realEstateObject));
            context.SaveChanges();
            return RedirectToAction("Object", new {realObject.Entity.Id});
        }

        private RealtyObject Map(RealEstateObject realEstateObject)
        {
            return new()
            {
                Id = realEstateObject.Id,
                Description = realEstateObject.Description,
                Title = realEstateObject.Title,
            };
        }
        
        private static RealEstateObject Map(RealtyObject realObject)
        {
            return new RealEstateObject
            {
                Id = realObject.Id,
                Description = realObject.Description,
                Title = realObject.Title,
                Photos = realObject.Images.Select(x => new Photo() {Url = x.Url}).ToArray(),
            };
        }

        [HttpPost]
        public IActionResult Object([FromRoute]int id, RealEstateObject realEstateObject)
        {
            var realObject = context.Objects.Single(x => x.Id == id);
            realObject.Description = realEstateObject.Description;
            realObject.Title = realEstateObject.Title;
            context.SaveChanges();
            
            return RedirectToAction("Object", new {id});
        }

        [HttpGet]
        public IActionResult Object(int id)
        {
            var realtyObject  = context
                .Objects
                .Include(x=>x.Images)
                .SingleOrDefault(x => x.Id == id);
            if (realtyObject == null)
            {
                return NotFound();
            }

            return View(new RealEstateObject()
            {
                Id = id,
                Description = realtyObject.Description,
                Title = realtyObject.Title,
                Photos = realtyObject.Images.Select(x=> new Photo(){Url = x.Url, Id = x.Id}).ToArray(),
            });
        }

        public async Task<IActionResult> UploadPhoto([FromRoute]int id, IFormFile file)
        {
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var client = new BlobContainerClient(ConnectionString, "photos");
            var name = $"{Guid.NewGuid().ToString()}-{file.FileName}";
            await client.UploadBlobAsync(name, memoryStream);

            var url = $"{client.Uri}/{name}";

            await context.Images.AddAsync(new ObjectImage()
            {
                Url = url,
                RealtyObjectId = id,
            });

            await context.SaveChangesAsync();
            
            return RedirectToAction("Object", new {id});
        }

        
        [HttpDelete]
        public IActionResult Photo([FromRoute]int id)
        {
            var image = context.Images.Single(x => x.Id == id);
            context.Images.Remove(image);

            context.SaveChanges();

            return Json(new {Success = true});
        }

        [HttpGet]
        [Route("{controller}/object/{id}/bookings")]
        public IActionResult Calendar(int id, DateTime? date)
        {
            var dateValue = date ?? DateTime.Now;

            var startDate = (new DateTime(dateValue.Year, dateValue.Month, 1)).StartOfWeek(DayOfWeek.Monday);
            var finishDate = (new DateTime(dateValue.AddMonths(1).Year, dateValue.AddMonths(1).Month, 1)).StartOfWeek(DayOfWeek.Monday).AddDays(7);


            var allBookings = context.Bookings.ToArray();
            
            var bookings = context.Bookings.Include(x=>x.Client).Where(x =>
                x.ObjectId == id 
                && ((x.From >= startDate && x.From < finishDate) ||
                                     (x.To >= startDate && x.To < finishDate))).ToArray();
            var dates = new List<BookingsInDate>();
            for (var dt = startDate; dt < finishDate; dt = dt.AddDays(1))
            {
                var bookingsByDate = GetBookingsByDate(bookings, dt);
                
                dates.Add(new BookingsInDate()
                {
                    Date = dt,
                    Bookings = bookingsByDate,
                });
            }
            
            return View(dates);
        }

        private Booking[] GetBookingsByDate(RealtyBooking[] bookings, DateTime dt)
        {
            var result = new List<Booking>();
            foreach (var realtyBooking in bookings)
            {
                if (realtyBooking.From <= dt && realtyBooking.To >= (dt.AddDays(1)))
                {
                    result.Add(new Booking()
                    {
                        Id = realtyBooking.Id,
                        Title = realtyBooking.Client.Name,
                        StartHour = 0,
                        FinishHour = 24,
                    });
                    continue;
                }

                if (dt.AddDays(1) > realtyBooking.From && dt.AddDays(1) <= realtyBooking.To)
                {
                    result.Add(new Booking()
                    {
                        Id = realtyBooking.Id,
                        Title = realtyBooking.Client.Name,
                        StartHour = realtyBooking.From.Hour,
                        FinishHour = 24,
                    });
                    continue;
                }

                if (dt >= realtyBooking.From && dt < realtyBooking.To)
                {
                    result.Add(new Booking()
                    {
                        Id = realtyBooking.Id,
                        Title = realtyBooking.Client.Name,
                        StartHour = 0,
                        FinishHour = realtyBooking.To.Hour,
                    });
                    continue;
                }

                if (realtyBooking.From > dt && realtyBooking.To < (dt.AddDays(1)))
                {
                    result.Add(new Booking()
                    {
                        Id = realtyBooking.Id,
                        Title = realtyBooking.Client.Name,
                        StartHour = realtyBooking.From.Hour,
                        FinishHour = realtyBooking.To.Hour,
                    });
                }
            }

            return result.OrderBy(x=>x.StartHour).ToArray();
        }
    }

    public class BookingsInDate
    {
        public DateTime Date { get; set; }
        public Booking[] Bookings { get; set; }
    }

    public class Booking
    {
        public int Id { get; set; }
        public int StartHour { get; set; }
        public int FinishHour { get; set; }
        public string Title { get; set; }
    }
}