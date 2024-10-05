

using API.Controllers;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace API.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddApiVersioning(
               options =>
               {
                   options.ReportApiVersions = true;
               });

            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });


            services.AddSwaggerGen(
               options =>
               {
                  

                   // add a custom operation filter which sets default values
                   options.OperationFilter<SwaggerDefaultValues>();

                   // integrate xml comments
                   options.IncludeXmlComments(XmlCommentsFilePath);
               });

            return services;
        }

        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = AppContext.BaseDirectory;
                var fileName = typeof(GetByIdEndpoint).GetTypeInfo().Assembly.GetName().Name + ".xml";

                return Path.Combine(basePath, fileName);
            }
        }
    }
}
