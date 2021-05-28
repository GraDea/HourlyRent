using System;

namespace HourlyRate.Data.Models
{
    public class CreateBooking
    {
        public int ObjectId { get; set; }
        public int ClientId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
    
    public class CreateBookingResult
    {
        public bool IsSuccess { get; set; }
    }
}