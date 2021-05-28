using System;
using System.Linq;

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
    
    public class BookingResult
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Price { get; set; }
        public string ClientName { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
        public static BookingResult FromBooking(RealtyBooking booking)
        {
            return new BookingResult()
                   {
                       Id = booking.Id,
                       From = booking.From,
                       Price = booking.Price,
                       Title = booking.Object.Title,
                       Address = booking.Object.Address,
                       To = booking.To,
                       ClientName = booking.Client.Name,
                       Image = booking.Object.Images.OrderByDescending(i=>i.Priority).FirstOrDefault()?.Url,
                       Description = booking.Object.Description
                   };
        }


        public string Description { get; set; }


        public string Image { get; set; }
    }
}