using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HourlyRate.Data;
using HourlyRate.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
            return await this.Objects.ToListAsync();
        }


        private IIncludableQueryable<RealtyObject, ICollection<ObjectImage>> Objects
        {
            get
            {
                return this.context.Objects
                           .Include(o=>o.Images);
            }
        }


        [HttpGet()]
        [Route("api/[controller]/{id}")]
        public async Task<RealtyObject> GetById(int id)
        {
            return await this.Objects.FirstAsync(o=>o.Id == id);
        }
    }
}