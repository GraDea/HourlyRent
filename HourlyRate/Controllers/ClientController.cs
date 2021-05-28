using System.Linq;
using HourlyRate.Data;
using Microsoft.AspNetCore.Mvc;

namespace HourlyRate.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private MainDbContext Context;
        public ClientController(MainDbContext context)
        {
            this.Context = context;
        }
        [HttpGet()]
        [Route("api/[controller]")]
        public Client GetClient()
        {
            return this.Context.Clients.FirstOrDefault();
        }
    }
}