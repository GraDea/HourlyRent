using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HourlyRate.Data;
using HourlyRate.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HourlyRate.Controllers
{
    [ApiController]
    public class ObjectController : ControllerBase
    {
        private readonly MainDbContext context;
        public ObjectController(MainDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet()]
        [Route("api/[controller]/find")]
        public async Task<IEnumerable<RealtyObject>> FindClient()
        {
            return await this.context.Objects.ToListAsync();
        }
        
        [HttpGet()]
        [Route("api/[controller]/{id}")]
        public async Task<RealtyObject> GetById(int id)
        {
            return await this.context.Objects.FirstAsync(o=>o.Id == id);
        }
    }
}