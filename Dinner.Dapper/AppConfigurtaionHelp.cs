using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dinner.Dapper
{
    public class AppConfigurtaionHelp
    {
        public static IConfiguration Configuration { get; set; }
        static AppConfigurtaionHelp()
        {
            Configuration = new ConfigurationBuilder()
               .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
               .Build();
        }
    }
}
