using System.Collections.Generic;
using System.Linq;
using HourlyRate.Data;
using HourlyRate.Data.Models;
using HourlyRate.Migrations;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<RealtyBooking> GetBooking(int id)
        {
            return this.context.Bookings.FirstOrDefault(p => p.Id == id);
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
            if (booking != null)
            {
                return new ActionResult<CreateBookingResult>(new CreateBookingResult{IsSuccess = false});
            }
            booking = new RealtyBooking()
                      {
                          ClientId = 1,
                          From = book.From,
                          To = book.To,
                          ObjectId = book.ObjectId
                      };
            this.context.Bookings.Add(booking);
            this.context.SaveChanges();
            return new ActionResult<CreateBookingResult>(new CreateBookingResult(){IsSuccess = true});
        }
    }
}