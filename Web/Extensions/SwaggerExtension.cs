using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsAPI.Web.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Posts Rest API",
                        Version = "v1",
                        Description = "Simple REST API built with ASP.NET Core 3.1",
                        Contact = new OpenApiContact
                        {
                            Name = "Junaid Aslam",
                            Url = new Uri("https://ajuni880.github.io/")
                        }
                    });
            });

            return services;
        }
    }
}
