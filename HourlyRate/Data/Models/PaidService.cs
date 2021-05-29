using System.Collections.Generic;

namespace HourlyRate.Data.Models
{
    public class PaidService
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<RealtyObject> Objects { get; set; }
        public IEnumerable<RealtyBooking> Bookings { get; set; }
    }
}