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
        public string Price { get; set; }
        public IEnumerable<string> Options { get; set; }
    }

    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }
}