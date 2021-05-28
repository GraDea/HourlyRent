using System.Collections.Generic;
using System.Linq;
using HourlyRate.Data;
using HourlyRate.Data.Models;
using HourlyRate.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace HourlyRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly MainDbContext context;
        public PriceController(MainDbContext context)
        {
            this.context = context;
        }
        [HttpGet("{id}")]
        public IEnumerable<RealtyPrice> GetClient(int id)
        {
            return this.context.Prices.Where(p => p.Id == id).ToList();
        }
    }
}