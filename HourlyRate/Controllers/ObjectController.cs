using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HourlyRate.Data;
using HourlyRate.Data.Models;
using HourlyRate.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HourlyRate.Controllers
{
    [ApiController]
    public class ObjectController : ControllerBase
    {
        private readonly MainDbContext context;

        private IQueryable<RealtyObject> objects => this.context.Objects
                                                        .Include(c => c.Images)
                                                        .Include(c => c.AvailableEventTypes)
                                                        .Include(c=>c.Prices)
                                                        .Include(c=>c.Bookings);


        public ObjectController(MainDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [Route("api/[controller]/get-all")]
        public async Task<IEnumerable<RealtyObject>> GetAll()
        {
            return await this.objects.ToListAsync();
        }
        
        [HttpPost]
        [Route("api/[controller]/find")]
        public async Task<IEnumerable<RealtyObject>> Filter(ObjectsFilter filter)
        {
            Expression<Func<RealtyObject, bool>> expression = c => true;

            if (!string.IsNullOrEmpty(filter?.Region))
            {
                expression = expression.And(c => c.Region == filter.Region);
            }
            
            if (filter?.Square?.From.HasValue ?? false)
            {
                expression = expression.And(c => c.Capacity >= filter.Square.From);
            }
            
            if (filter?.Square?.To.HasValue ?? false)
            {
                expression = expression.And(c => c.Capacity <= filter.Square.To);
            }

            if (filter?.Price?.From.HasValue ?? false)
            {
                expression = expression.And(c => c.Prices.All(p=>p.Amount >= filter.Price.From.Value));
            }
            
            if (filter?.Price?.To.HasValue ?? false)
            {
                expression = expression.And(c => c.Prices.All(p=>p.Amount <= filter.Price.To.Value));
            }

            if (filter?.Date != null)
            {
                expression = expression.And(c => 
                                                !c.Bookings.Any(p=>p.From >= filter.Date.From && p.From <= filter.Date.To)
                                                && !c.Bookings.Any(p=>p.To >= filter.Date.From && p.To <= filter.Date.To));
                
            }
            
            return await this.objects.Where(expression).ToListAsync();
        }


        [HttpGet()]
        [Route("api/[controller]/{id}")]
        public async Task<RealtyObject> GetById(int id)
        {
            return await this.objects.FirstAsync(o => o.Id == id);
        }
    }

    public class ObjectsFilter
    {
        public SquareFilter Square { get; set; }

        public PriceFilter Price { get; set; }
        
        public DateFilter Date { get; set; }
        
        public string Region { get; set; }
    }

    public class DateFilter
    {
        public DateTime From { get; set; }
        
        public DateTime To { get; set; }
    }

    public class PriceFilter
    {
        public decimal? From { get; set; }
        
        public decimal? To { get; set; }
    }

    public class SquareFilter
    {
        public double? From { get; set; }
        
        public double? To { get; set; }
    }
}