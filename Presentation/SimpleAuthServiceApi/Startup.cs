using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleAuthServiceApi.Common.Mapper;

namespace SimpleAuthServiceApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerDocument(
                (config) => 
                {
                    config.PostProcess =
                    (document) =>
                    {
                        document.Info.Version = "v1";
                        document.Info.Title = "SimpleAuthService API";
                        document.Info.Description = "A simple identity management dan authentication service.";
                        document.Info.Contact = new NSwag.OpenApiContact()
                        {
                            Name = "Firdaus Bisma Suryakusuma",
                            Email = "firdausbismasuryakusuma@mail.ugm.ac.id"
                        };
                    };
                });

            var useCaseBootstrapper = new Bootstrapper();
            services.AddSingleton(useCaseBootstrapper.Mediator);

            services.AddControllers();

            services.AddSingleton<IMapper>(new Mapper(new MapperConfig().GetConfiguration()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
