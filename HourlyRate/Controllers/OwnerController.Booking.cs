using System.Collections.Generic;
using System.Linq;
using HourlyRate.Data.Models;
using HourlyRate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HourlyRate.Controllers
{
    public partial class OwnerController
    {
        [HttpGet]
        public IActionResult Booking([FromRoute]int id)
        {
            var booking =  this.context.Bookings.Include(b=>b.Object).Include(b=>b.Object.Images).Include(b=>b.Client)
                                .FirstOrDefault(b=>b.Id == id);
            if(booking==null)
                return NotFound();
            return View(BookingResult.FromBooking(booking));
        }

        [HttpPost]
        public IActionResult Cancel([FromRoute]int id)
        {
            var booking =  this.context.Bookings.FirstOrDefault(p => p.Id == id);
            this.context.Bookings.Remove(booking);
            this.context.SaveChanges();
            
            return RedirectToAction("Objects");
        }
    }
}