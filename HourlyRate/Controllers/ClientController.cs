using System.Linq;
using HourlyRate.Data;
using Microsoft.AspNetCore.Mvc;

namespace HourlyRate.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly MainDbContext context;
        public ClientController(MainDbContext context)
        {
            this.context = context;
        }
        [HttpGet()]
        [Route("api/[controller]")]
        public Client GetClient()
        {
            return this.context.Clients.FirstOrDefault();
        }
    }
}