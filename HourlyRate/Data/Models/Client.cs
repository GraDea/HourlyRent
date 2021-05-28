using System.Collections.Generic;

namespace HourlyRate.Data.Models
{
    public class RealtyClient
    {
        public RealtyClient()
        {
            this.Bookings = new HashSet<RealtyBooking>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<RealtyBooking> Bookings { get; set; }
    }
}