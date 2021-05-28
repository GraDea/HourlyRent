namespace HourlyRate.Data.Models
{
    public class RealtyObject
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        public string Title { get; set; }
        
        public ObjectType ObjectType { get; set; }
    }

    public enum ObjectType
    {
        Loft = 1
    }
}