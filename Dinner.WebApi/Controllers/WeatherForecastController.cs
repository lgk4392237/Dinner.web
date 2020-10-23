using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dinner.Common;
using Dinner.Model;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dinner.WebApi.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
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

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = AppSettings.GetApp("AppSettings:ConnectionString")
            })
            .ToArray();
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetUser(User user)
        {
            return Ok(user);
        }
        
    }
}
