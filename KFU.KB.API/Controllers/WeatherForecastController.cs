using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KFU.KB.API.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KFU.KB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
        [HttpPost]
        public async Task<IActionResult> GetAuthor([FromForm] string author)
        {
            
            Parse.ParseToAuthor(author);
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> GetBook([FromForm] string book)
        {
            Parse.ParseToBook(book);
            return Ok(book);
        }
    }
}
