using Configuration.RapidApi;
using CovidCases.BusinessRepository.ExportData;
using CovidCases.BusinessRepository.ExportData.Csv;
using CovidCases.BusinessRepository.ExportData.ExportBusiness;
using CovidCases.BusinessRepository.ExportData.Json;
using CovidCases.BusinessRepository.ExportData.Xml;
using CovidCases.BusinessRepository.RapidApi;
using DataAccess.Services.RapidApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;

namespace CovidCases.ServiceHelper
{
    /// <summary>
    /// Class to add custom services and configurations to the application
    /// </summary>
    /// <remarks>Author: Dariel Pérez</remarks>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Adds the custom services related to data access and business logic
        /// </summary>
        /// <param name="services">Collection of services in which the custom ones are added</param>
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IRapidApiService, RapidApiService>();
            services.AddScoped<IRapidApiBusinessRepository, RapidApiBusinessRepository>();
            services.AddSingleton<IRapidApiConfiguration, RapidApiConfiguration>();
            services.AddSingleton<IExportRepository, ExportRepository>();
            services.AddSingleton<ICsvExport, CsvExport>();
            services.AddSingleton<IJsonExport, JsonExport>();
            services.AddSingleton<IXmlExport, XmlExport>();
            services.AddSingleton<IExportBusinessRepository, ExportBusinessRepository>();
        }

        /// <summary>
        /// Adds the configuration of Swagger to the application and reads 
        /// the properties for its configuration from the application´s configuration settings file
        /// </summary>
        /// <param name="services">Collection of services in which the custom ones are added</param>
        /// <param name="Configuration">Represents a set of key/value application configuration properties.</param>
        public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddOpenApiDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info = new OpenApiInfo()
                    {
                        Version = Configuration.GetSection("OpenApiDocument:Version").Value,
                        Title = Configuration.GetSection("OpenApiDocument:Title").Value,
                        Description = Configuration.GetSection("OpenApiDocument:Description").Value,
                        TermsOfService = Configuration.GetSection("OpenApiDocument:TermsOfService").Value,
                        Contact = new OpenApiContact()
                        {
                            Name = Configuration.GetSection("OpenApiDocument:Contact:Name").Value,
                            Email = Configuration.GetSection("OpenApiDocument:Contact:Email").Value,
                            Url = Configuration.GetSection("OpenApiDocument:Contact:Url").Value
                        },
                        License = new OpenApiLicense
                        {
                            Name = Configuration.GetSection("OpenApiDocument:License:Name").Value,
                            Url = Configuration.GetSection("OpenApiDocument:License:Url").Value
                        },
                    };
                };
            });
        }
    }
}
