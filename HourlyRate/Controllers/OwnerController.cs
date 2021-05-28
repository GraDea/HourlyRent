using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using HourlyRate.Data;
using HourlyRate.Data.Models;
using HourlyRate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HourlyRate.Controllers
{
    public class OwnerController : Controller
    {
        private readonly MainDbContext context;
        public string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=hourlyrentphotos;AccountKey=v7UBtaQSmDxQRFBY50MmOSsRL6bJgPhqpC2TQ7vx68TaigXYFvQ0+yl+Eblav28gcq0Veo2wKP0x8RVlSPu/5A==;EndpointSuffix=core.windows.net";

        public OwnerController(MainDbContext context)
        {
            this.context = context;
        }

        public IActionResult Objects()
        {
            var realtyObjects = context
                .Objects
                .Include(x => x.Images)
                .Select(o => new RealEstateObject()
                {
                    Id = o.Id,
                    Description = o.Description,
                    Title = o.Title,
                    Photos = o.Images.Select(x => new Photo() {Url = x.Url}).ToArray(),
                }).ToArray();
            
            return View(realtyObjects);
        }

        [HttpPost]
        public IActionResult Object([FromRoute]int id, RealEstateObject realEstateObject)
        {
            var realObject = context.Objects.Single(x => x.Id == id);
            realObject.Description = realEstateObject.Description;
            realObject.Title = realEstateObject.Title;
            context.SaveChanges();
            
            return RedirectToAction("Object", new {id});
        }

        [HttpGet]
        public IActionResult Object(int id)
        {
            var realtyObject  = context
                .Objects
                .Include(x=>x.Images)
                .SingleOrDefault(x => x.Id == id);
            if (realtyObject == null)
            {
                return NotFound();
            }

            return View(new RealEstateObject()
            {
                Id = id,
                Description = realtyObject.Description,
                Title = realtyObject.Title,
                Photos = realtyObject.Images.Select(x=> new Photo(){Url = x.Url}).ToArray(),
            });
        }

        public async Task<IActionResult> UploadPhoto([FromRoute]int id, IFormFile file)
        {
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var client = new BlobContainerClient(ConnectionString, "photos");
            var name = $"{Guid.NewGuid().ToString()}-{file.FileName}";
            await client.UploadBlobAsync(name, memoryStream);

            var url = $"{client.Uri}/{name}";

            await context.Images.AddAsync(new ObjectImage()
            {
                Url = url,
                RealtyObjectId = id,
            });

            await context.SaveChangesAsync();
            
            return RedirectToAction("Object", new {id});
        }
    }
}