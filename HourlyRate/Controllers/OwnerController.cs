using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using HourlyRate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HourlyRate.Controllers
{
    public class OwnerController : Controller
    {
        public string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=hourlyrentphotos;AccountKey=v7UBtaQSmDxQRFBY50MmOSsRL6bJgPhqpC2TQ7vx68TaigXYFvQ0+yl+Eblav28gcq0Veo2wKP0x8RVlSPu/5A==;EndpointSuffix=core.windows.net";
        
        public IActionResult EditObject(RealEstateObject realEstateObject)
        {
            return RedirectToAction("Object", new {id = realEstateObject.Id});
        }

        public IActionResult Object(int id)
        {
            return View(new RealEstateObject()
            {
                Id = id,
                Description =
                    @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque vitae eleifend felis. Nam egestas nec dolor in semper. Vivamus eleifend facilisis sem, sagittis rhoncus nisi fermentum quis. Fusce vulputate, felis ut finibus porta, lorem ex bibendum sapien, id cursus felis ex dictum lorem. Aliquam erat volutpat. In eu urna dignissim, condimentum lacus non, dapibus nisi. Nullam magna justo, maximus nec dapibus in, fermentum et ex. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus id aliquet odio.

                In hac habitasse platea dictumst. Vestibulum consectetur in turpis pellentesque dignissim. Vestibulum a justo ac tortor rutrum fermentum. Aliquam rutrum venenatis massa a mattis. Nam vel lacus eget mi commodo mattis. Suspendisse euismod nulla at sapien semper posuere. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum ut mi lectus. Morbi congue neque id dictum vestibulum. Nunc semper accumsan felis in eleifend. Nunc enim augue, sollicitudin eget ultrices eget, maximus et lorem. Phasellus volutpat ligula suscipit congue rutrum. Aliquam luctus luctus ante sit amet hendrerit.",
                Title = "Лофт Ле Форт",
                Photos = new[]
                {
                    new Photo() {Url = "https://bc-lefort.ru/xml/Photos/317873.jpg"},
                    new Photo() {Url = "https://hourlyrentphotos.blob.core.windows.net/photos/88a5d965-3c78-45af-9eee-1f1282d1828f-1_YAaAjBYEDVI7ynN588t8fg.jpeg"},
                }
            });
        }

        public async Task<IActionResult> UploadPhoto(int id, IFormFile file)
        {
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var client = new BlobContainerClient(ConnectionString, "photos");
            var name = $"{Guid.NewGuid().ToString()}-{file.FileName}";
            var response = await client.UploadBlobAsync(name, memoryStream);

            var url = $"{client.Uri}/{name}";
            
            return RedirectToAction("Object", new {id});
        }
    }
}