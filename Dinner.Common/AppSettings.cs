using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dinner.Common
{
    public class AppSettings
    {
        public static IConfiguration Configuration { get; set; }
        //static string contentPath { get; set; }
        //public AppSettings()
        //{
        //    Configuration = new ConfigurationBuilder()
        //        .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
        //        .Build();
        //}
        public AppSettings(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }
        public static string GetApp(string key)
        {
            return Configuration[key];
        }
    }
}
