using System;
using System.Collections.Generic;
using System.Linq;

namespace HourlyRate.Models
{
    public class RealEstateObject
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public IReadOnlyCollection<Photo> Photos { get; set; }

        public string ThumbnailUrl => Photos.FirstOrDefault()?.Url;
        public string Address { get; set; }
        public string Region { get; set; }
        public string Price { get; set; }
        public int Capacity { get; set; }
        public double TotalArea { get; set; }
        public decimal PriceValue{ get; set; }
        public IEnumerable<string> Options { get; set; }
        
        public List<ServiceModel> Services { get; set; }
    }

    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }
    
    public class ServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}