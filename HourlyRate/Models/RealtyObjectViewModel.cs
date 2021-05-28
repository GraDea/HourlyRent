using System;
using System.Collections.Generic;
using System.Linq;
using HourlyRate.Data.Models;

namespace HourlyRate.Models
{
    public class RealtyObjectViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        public string Title { get; set; }
        
        public ObjectType ObjectType { get; set; }
        
        public IEnumerable<string> AvailableEventTypes { get; set; }
        
        public int Rating { get; set; }
        
        public string Region { get; set; }
        
        public double TotalSpace { get; set; }
        
        public int Capacity { get; set; }
        
        public string Address { get; set; }
        
        public double? Lat { get; set; }
        
        public double? Lon { get; set; }
        
        public virtual IEnumerable<string> Images { get; set; }
        
        public virtual IEnumerable<BookingViewModel> Bookings { get; set; }
        
        public decimal Price { get; set; }
        
        public virtual IEnumerable<string> Services { get; set; }
        
        public static RealtyObjectViewModel FromRealtyObject(RealtyObject realtyObject)
        {
            return new RealtyObjectViewModel()
                   {
                       Id = realtyObject.Id,
                       Address = realtyObject.Address,
                       Capacity = realtyObject.Capacity,
                       Description = realtyObject.Description,
                       Lat = realtyObject.Lat,
                       Lon = realtyObject.Lon,
                       Rating = realtyObject.Rating,
                       Region = realtyObject.Region,
                       Title = realtyObject.Title,
                       ObjectType = realtyObject.ObjectType,
                       TotalSpace = realtyObject.TotalSpace,
                       AvailableEventTypes = realtyObject.AvailableEventTypes.Select(c => c.Name),
                       Services = realtyObject.Services.Select(c => c.Title),
                       Images = realtyObject.Images.OrderBy(c => c.Priority).Select(c => c.Url),
                       Bookings = realtyObject.Bookings.Select(c=> new BookingViewModel(){From = c.From, To = c.To}),
                       Price = realtyObject.Prices.FirstOrDefault()?.Amount ?? 0
                   };
        }
    }

    public class BookingViewModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}