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
        public decimal Price { get; set; }
        public string ErrorText { get; set; }


        public static CreateBookingResult Error(string text)
        {
            return new CreateBookingResult()
                   {
                       ErrorText=text,
                       IsSuccess = false
                   };
        }
    }
}