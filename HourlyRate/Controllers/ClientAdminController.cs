using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using HourlyRate.Data;
using HourlyRate.Data.Models;
using HourlyRate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HourlyRate.Controllers
{
    public class ClientAdminController : Controller
    {
        private readonly MainDbContext context;
        
        public ClientAdminController(MainDbContext context)
        {
            this.context = context;
        }

        public IActionResult ObjectList()
        {
            var result = new List<BookingResult>();
            var bookings =  this.context.Bookings.Include(b=>b.Object).Include(b=>b.Object.Images).Include(b=>b.Client).Include(b=>b.PaidServices)
                                .ToList();
            foreach (var booking in bookings)
            {
                result.Add(BookingResult.FromBooking(booking));
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Cancel([FromRoute]int id)
        {
            var booking =  this.context.Bookings.FirstOrDefault(p => p.Id == id);
            this.context.Bookings.Remove(booking);
            this.context.SaveChanges();
            
            return RedirectToAction("ObjectList");
        }
    }
}