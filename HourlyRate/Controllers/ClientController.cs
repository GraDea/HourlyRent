﻿using System.Linq;
using HourlyRate.Data;
using HourlyRate.Data.Models;
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
        public RealtyClient GetClient()
        {
            return this.context.Clients.FirstOrDefault();
        }
    }
}