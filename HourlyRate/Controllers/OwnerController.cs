using System.Collections.Generic;
using HourlyRate.Models;
using Microsoft.AspNetCore.Mvc;

namespace HourlyRate.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult EditObject(RealEstateObject realEstateObject)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Object(int id)
        {
            return View(new RealEstateObject()
            {
                Description =
                    @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque vitae eleifend felis. Nam egestas nec dolor in semper. Vivamus eleifend facilisis sem, sagittis rhoncus nisi fermentum quis. Fusce vulputate, felis ut finibus porta, lorem ex bibendum sapien, id cursus felis ex dictum lorem. Aliquam erat volutpat. In eu urna dignissim, condimentum lacus non, dapibus nisi. Nullam magna justo, maximus nec dapibus in, fermentum et ex. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus id aliquet odio.

                In hac habitasse platea dictumst. Vestibulum consectetur in turpis pellentesque dignissim. Vestibulum a justo ac tortor rutrum fermentum. Aliquam rutrum venenatis massa a mattis. Nam vel lacus eget mi commodo mattis. Suspendisse euismod nulla at sapien semper posuere. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum ut mi lectus. Morbi congue neque id dictum vestibulum. Nunc semper accumsan felis in eleifend. Nunc enim augue, sollicitudin eget ultrices eget, maximus et lorem. Phasellus volutpat ligula suscipit congue rutrum. Aliquam luctus luctus ante sit amet hendrerit.",
                Title = "Лофт Ле Форт",
                Photos = new[] {new Photo() {Url = "https://bc-lefort.ru/xml/Photos/317873.jpg"}}
            });
        }
    }
}