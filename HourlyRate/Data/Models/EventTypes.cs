using System.Collections.Generic;

namespace HourlyRate.Data.Models
{
    public class EventType
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public virtual ICollection<RealtyObject> Objects { get; set; }
    }
}