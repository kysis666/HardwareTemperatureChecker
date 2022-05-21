using Fox.Configs;
using Fox.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Fox
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = configurationBuilder.Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(config);

            ApplicationServicesConfig.ConfigureServices(serviceCollection, config);
            LoggingConfig.ConfigureServices(serviceCollection, config);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<IReportGenerator>().Generate();
            await Task.Delay(TimeSpan.FromSeconds(6));
        }
    }
}
