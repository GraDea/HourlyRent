using System.Linq;
using System.Net;
using HourlyRate.Data;
using HourlyRate.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace HourlyRate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly MainDbContext context;
        public ClientController(MainDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<RealtyClient> GetClient()
        {
            var result = this.context.Clients.FirstOrDefault();
            return result;
        }
    }
}