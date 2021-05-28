using System;

namespace HourlyRate.Data.Models
{
    public class RealtyPrice
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public decimal Amount { get; set; }
        public int? Day { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}