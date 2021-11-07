using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace CrudUsers.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    string appsettingsJsonVolume = Environment.GetEnvironmentVariable("APPSETTINGS_VOLUME");

                    builder
                        .SetBasePath(ctx.HostingEnvironment.ContentRootPath)
                        .AddJsonFile($"{appsettingsJsonVolume}/appsettings.json", true, true)
                        .AddJsonFile($"{appsettingsJsonVolume}/appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
