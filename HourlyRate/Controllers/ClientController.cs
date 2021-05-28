using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        
        [HttpPost]
        public async Task<RealtyClient> AddClient(AddClientRequest request)
        {
           
            var existingClient = this.context.Clients.FirstOrDefault(c=>c.Phone == request.Phone);

            if (existingClient != null) return existingClient;

            var client = new RealtyClient()
                         {
                             Name = request.Name,
                             Phone = request.Phone
                         };
            
            var result = await this.context.Clients.AddAsync(client);
            await this.context.SaveChangesAsync();
            return this.context.Clients.FirstOrDefault(c=>c.Phone == request.Phone);
        }
    }

    public class AddClientRequest
    {
        [Required]
        public string Phone { get; set; }
        
        public string Name { get; set; }
    }
}