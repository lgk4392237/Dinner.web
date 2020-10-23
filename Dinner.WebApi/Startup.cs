using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dinner.Common;
using Dinner.WebApi.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Dinner.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var apiName = "Dinner.WebApi";
            services.AddSwaggerGen(p =>
            {
                p.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                p.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "V1",
                    Title = $"{apiName}�ӿ��ĵ�-Netcore 3.0",
                    Description = $"{apiName} HTTP API V1"
                });
                p.OrderActionsBy(o => o.RelativePath);
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Dinner.WebApi.xml");
                p.IncludeXmlComments(xmlPath, true);
                var xmlModelPath = Path.Combine(AppContext.BaseDirectory, "Dinner.Model.xml");
                p.IncludeXmlComments(xmlModelPath,true);

                //��header�����token�����ݵ���̨
                p.OperationFilter<SecurityRequirementsOperationFilter>();
                p.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });
            });
            services.AddControllers();
            services.AddSingleton(new AppSettings(Configuration));
            services.AddAuthorizationSetup();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(p =>
            {
                p.SwaggerEndpoint($"/swagger/V1/swagger.json", "Dinner.WebApi V1");
                p.RoutePrefix = "";
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=WeatherForecast}/{action=Get}/{id?}"
                    );
            });
        }
    }
}
