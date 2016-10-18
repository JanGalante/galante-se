﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using galante_se.Services;

namespace galante_se
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            //ConfigurationBuilder define configuration sources for the application
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            //.AddJsonFile("appsettings.json");

            //Saves the configuration in my property. Convinient if we add many sources to the builder
            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(provider => Configuration); //Scott Allen: The syntax is a little bit wierd. If you give me an service provider, i give you a configuration
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IGreeter greeter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseWelcomePage();
            //app.UseRuntimeInfoPage(); //removed from Diagnostics, but will be back in future

            app.Run(async (context) =>
            {
                //var greeting = Configuration["greeting"]; //getting the value from my configuration files
                var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}