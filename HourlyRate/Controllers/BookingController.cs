using System;
using System.Collections.Generic;
using System.Linq;
using HourlyRate.Data;
using HourlyRate.Data.Models;
using HourlyRate.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using PaidService = HourlyRate.Data.Models.PaidService;

namespace HourlyRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly MainDbContext context;
        public BookingController(MainDbContext context)
        {
            this.context = context;
        }
        [HttpGet("{id}")]
        public ActionResult<List<BookingResult>> GetBooking(int id)
        {
            var result = new List<BookingResult>();
            var bookings =  this.context.Bookings.Include(b=>b.Object).Include(b=>b.Client).Include(b=>b.PaidServices)
                       .Where(p=>p.ObjectId == id).ToList();
            foreach (var booking in bookings)
            {
                result.Add(BookingResult.FromBooking(booking));
            }
            return result;
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(int id)
        {
            var booking =  this.context.Bookings.FirstOrDefault(p => p.Id == id);
            this.context.Bookings.Remove(booking);
            this.context.SaveChanges();
            return this.Accepted();
        }
        
        [HttpPost()]
        public ActionResult<CreateBookingResult> Booking([FromBody]CreateBooking book)
        {
            var booking =  this.context.Bookings.FirstOrDefault(p => p.Id == book.ObjectId && 
                                                                     ((p.From <= book.From && p.To >= book.From) || (p.From <= book.To && p.To >= book.To)));
            var price = this.context.Prices.FirstOrDefault(p => p.ObjectId == book.ObjectId) ;
            if (booking != null)
            {
                return new ActionResult<CreateBookingResult>(CreateBookingResult.Error("Время занято"));
            }

            if (price == null)
            {
                return new ActionResult<CreateBookingResult>(CreateBookingResult.Error("Цена не найдена"));
            }
            
            if (book.From > book.To)
            {
                return new ActionResult<CreateBookingResult>(CreateBookingResult.Error("Неверные даты"));
            }
            
            if ((book.To-book.From).TotalHours <0)
            {
                return new ActionResult<CreateBookingResult>(CreateBookingResult.Error("Менее одного часа"));
            }

            booking = new RealtyBooking()
                      {
                          ClientId = 1,
                          From = book.From,
                          To = book.To,
                          ObjectId = book.ObjectId,
                          Price = (price?.Amount ?? 0) * Math.Ceiling((decimal)(book.To-book.From).TotalHours),
                          PaidServices = new HashSet<PaidService>()
                      };
            
            if (book.PaidServices != null)
            {
                foreach (var service in book.PaidServices)
                {
                    var paidService = this.context.PaidServices.First(p => p.Id == service);
                    booking.Price += paidService.Price;
                    booking.PaidServices.Add(paidService);
                }
            }
            
            this.context.Bookings.Add(booking);
            this.context.SaveChanges();
            return new ActionResult<CreateBookingResult>(new CreateBookingResult()
                                                         {
                                                             IsSuccess = true,
                                                             Price = booking.Price
                                                         });
        }
    }
}