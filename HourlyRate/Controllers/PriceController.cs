using System.Linq;
using HourlyRate.Data;
using HourlyRate.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace HourlyRate.Controllers
{
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly MainDbContext context;
        public PriceController(MainDbContext context)
        {
            this.context = context;
        }
        [HttpGet("id")]
        [Route("api/[controller]")]
        public RealtyClient GetClient(int id)
        {
            return this.context.
        }
    }
}