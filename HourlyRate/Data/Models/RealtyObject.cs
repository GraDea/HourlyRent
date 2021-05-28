using System.Collections.Generic;

namespace HourlyRate.Data.Models
{
    public class RealtyObject
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        public string Title { get; set; }
        
        public ObjectType ObjectType { get; set; }
        
        public virtual ICollection<EventType> AvailableEventTypes { get; set; }
        
        public int Rating { get; set; }
        
        public string Region { get; set; }
        
        public double TotalSpace { get; set; }
        
        public int Capacity { get; set; }
        
        public double? Lat { get; set; }
        
        public double? Lon { get; set; }
        
        public virtual ICollection<ObjectImage> Images { get; set; }
        
        public virtual ICollection<RealtyBooking> Bookings { get; set; }
        
        public virtual ICollection<RealtyPrice> Prices { get; set; }
    }

    public enum ObjectType
    {
        Loft = 1
    }
}