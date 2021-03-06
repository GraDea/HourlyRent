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
            var services = this.context.Services.ToArray();
            var paidServices = this.context.PaidServices.ToArray();
            var realtyObjects = context
                .Objects
                .Include(x => x.Images)
                .Include(x=>x.Services)
                .Include(x=>x.Prices)
                .Include(x=>x.PaidServices)
                .Select(o => Map(o,services,paidServices)).ToArray();
            
            return View(realtyObjects);
        }

        [HttpGet]
        public IActionResult New()
        {
            var realEstateObject = new RealEstateObject();
            realEstateObject.Services = this.context.Services.Select(Map).ToList();
            realEstateObject.PaidServices = this.context.PaidServices.Select(Map).ToList();
            return View(realEstateObject);
        }

        [HttpPost]
        public IActionResult New(RealEstateObject realEstateObject)
        {
            var realObject = context.Objects.Add(Map(realEstateObject));
            if (realEstateObject.Services != null)
            {
                foreach (var service in realEstateObject.Services.Where(s=>s.IsSelected))
                {
                    realObject.Entity.Services.Add(Map(service));
                }
            }
            if (realEstateObject.PaidServices != null)
            {
                foreach (var service in realEstateObject.PaidServices.Where(s=>s.IsSelected))
                {
                    realObject.Entity.PaidServices.Add(Map(service));
                }
            }
            realObject.Entity.Prices = new List<RealtyPrice>(){new RealtyPrice()
                                                               {
                                                                   Amount = 0
                                                               }};
            context.SaveChanges();
            return RedirectToAction("Object", new {realObject.Entity.Id});
        }

        private static Service Map(ServiceModel service)
        {
            return new Service()
                   {
                       Id = service.Id,
                       Title = service.Name
                   };
        }
        
        private static PaidService Map(PaidServiceModel service)
        {
            return new PaidService()
                   {
                       Id = service.Id,
                       Title = service.Name,
                       Price = service.Price
                   };
        }
        
        private static PaidServiceModel Map(PaidService service)
        {
            return new PaidServiceModel()
                   {
                       Id = service.Id,
                       Name = service.Title,
                       Price = service.Price
                   };
        }
        
        private static ServiceModel Map(Service service)
        {
            return new ServiceModel()
                   {
                       Id = service.Id,
                       Name = service.Title
                   };
        }
        
        private static ServiceModel Map(Service service, bool isSelected)
        {
            return new ServiceModel()
                   {
                       Id = service.Id,
                       Name = service.Title,
                       IsSelected = isSelected
                   };
        }
        
        private static PaidServiceModel Map(PaidService service, bool isSelected)
        {
            return new PaidServiceModel()
                   {
                       Id = service.Id,
                       Name = service.Title,
                       Price = service.Price,
                       IsSelected = isSelected
                   };
        }
        
        private static RealtyObject Map(RealEstateObject realEstateObject)
        {
            return new RealtyObject()
            {
                Id = realEstateObject.Id,
                Description = realEstateObject.Description,
                Title = realEstateObject.Title,
                Address = realEstateObject.Address,
                Region = realEstateObject.Region,
                
            };
        }
        
        private static RealEstateObject Map(RealtyObject realObject, Service[] services, PaidService[] paidServices)
        {
            return new RealEstateObject
            {
                Id = realObject.Id,
                Description = realObject.Description,
                Title = realObject.Title,
                Photos = realObject.Images.Select(x => new Photo() {Url = x.Url}).ToArray(),
                Price = $"{realObject.Prices.FirstOrDefault()?.Amount.ToString() ?? "???"} ?? /??????????",
                PriceValue = realObject.Prices.FirstOrDefault()?.Amount ?? 0,
                Region = realObject.Region,
                Address = realObject.Address,
                Capacity = realObject.Capacity,
                TotalArea = realObject.TotalSpace,
                Options = realObject.Services.Select(x=>x.Title).ToArray(),
                Services = services.Select(s=>Map(s, realObject.Services.Any(srv=>srv.Id == s.Id))).ToList(),
                PaidServices = paidServices.Select(s=>Map(s, realObject.PaidServices.Any(srv=>srv.Id == s.Id))).ToList()
            };
        }

        [HttpPost]
        public IActionResult Object([FromRoute]int id, RealEstateObject realEstateObject)
        {
            var realObject = context.Objects.Include(s=>s.Services).Include(s=>s.PaidServices).Single(x => x.Id == id);
            realObject.Description = realEstateObject.Description;
            realObject.Title = realEstateObject.Title;
            realObject.Address = realEstateObject.Address;
            realObject.Region = realEstateObject.Region;
            realObject.Capacity = realEstateObject.Capacity;
            realObject.TotalSpace = realEstateObject.TotalArea;

            var price = this.context.Prices.First(c => c.ObjectId == id);
            price.Amount = realEstateObject.PriceValue;
            this.context.Prices.Update(price);
            if (realEstateObject.Services != null)
            {
                foreach (var service in realObject.Services)
                {
                    if (realEstateObject.Services.Where(s=>s.IsSelected).All(s => s.Id != service.Id))
                    {
                        realObject.Services.Remove(service);
                    }
                }
                
                foreach (var service in realEstateObject.Services.Where(s=>s.IsSelected))
                {
                    if (realObject.Services.All(s => s.Id != service.Id))
                    {
                        realObject.Services.Add(Map(service));
                    }
                }
            }
            
            if (realEstateObject.PaidServices != null)
            {
                foreach (var paidService in realObject.PaidServices)
                {
                    if (realEstateObject.PaidServices.Where(s=>s.IsSelected).All(s => s.Id != paidService.Id))
                    {
                        realObject.PaidServices.Remove(paidService);
                    }
                }
                
                foreach (var paidService in realEstateObject.PaidServices.Where(s=>s.IsSelected))
                {
                    if (realObject.PaidServices.All(s => s.Id != paidService.Id))
                    {
                        realObject.PaidServices.Add(Map(paidService));
                    }
                }
            }
            
            context.SaveChanges();
            
            return RedirectToAction("Object", new {id});
        }

        [HttpGet]
        public IActionResult Object(int id)
        {
            var services = this.context.Services.ToArray();
            var paidServices = this.context.PaidServices.ToArray();
            var realtyObject  = context
                .Objects
                .Include(x=>x.Images)
                .Include(x=>x.Services)
                .Include(x=>x.Prices)
                .Include(x=>x.PaidServices)
                .SingleOrDefault(x => x.Id == id);
            if (realtyObject == null)
            {
                return NotFound();
            }

            return View(Map(realtyObject,services,paidServices));

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
        [Route("{controller}/object/{id}/bookings", Name = "Calendar")]
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

            var obj = this.context.Objects.First(c => c.Id == id);
            this.ViewBag.Address = obj.Address;
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