using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HourlyRate.Data.Models
{
    public class Service
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public virtual ICollection<RealtyObject> Objects { get; set; }
    }
}