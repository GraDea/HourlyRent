using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HourlyRate.Data.Models
{
    public class RealtyBooking
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public int ClientId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Price { get; set; }
        
        [ForeignKey("ClientId")]
        public virtual RealtyClient Client { get; set; }
        
        [ForeignKey("ObjectId")]
        public virtual RealtyObject Object { get; set; }
    }
}