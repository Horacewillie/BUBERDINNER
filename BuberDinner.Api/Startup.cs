using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Infastructure;
using BuberDinner.Infastructure.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BuberDinner.Api.Middleware;
using BuberDinner.Api.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using BuberDinner.Api.Error;
using Microsoft.AspNetCore.Http;

namespace BuberDinner.Api
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
            services.Configure<JwtSettings>(Configuration.GetSection(JwtSettings.SectionName));
            services.AddApplication()
                    .AddInfastructure();
            
            //ExceptionHandlingFilterAttribute
            // services.AddControllers(options => options.Filters.Add(typeof(ErrorHandlingFilterAttribute)));

             services.AddControllers();
             //services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Error Handling Middleware
            //app.UseMiddleware<ErrorHandlingMiddleware>();
            
            //GlobalErrorHandling
            app.UseExceptionHandler("/error");

            //Using minimal api approach to avoid creating an error controller

     //    app.Map("/error", (HttpContext context) => 
        //    {
        //         Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        //         return Results.Problem;
        //    });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
