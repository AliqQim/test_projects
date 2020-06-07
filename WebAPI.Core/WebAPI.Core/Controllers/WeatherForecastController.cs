using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Core.Controllers
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


        /// <summary>
        /// вычисление среднего значения. при чем тут температура? 
        /// ну это же <see cref="WeatherForecastController"/>
        /// </summary>
        /// <param name="value1">первое значение температуры</param>
        /// <param name="value2">второе значение температуры</param>
        /// <returns>среднее арифметическое двух значений</returns>
        /// <remarks>я тебе еще раз говорю: вычисление среднего значения!</remarks>
        [HttpPost]
        public double GetAverageTemperatures(double value1, double value2)
        {
            return (value1 + value2) / 2;
        }


        public class Person
        {
            public string Name { get; set; } = null!;
            public string? LastName { get; set; }

            [Range(0, 120)]
            public int Age { get; set; }

            public bool IsFemale { get; set; }

        }

        [HttpPost]
        public bool IsAvailableForChattingUp(Person person)
        {
            return person.IsFemale && person.Age >= 18 && person.Age <= 45;
        }

    }
}
