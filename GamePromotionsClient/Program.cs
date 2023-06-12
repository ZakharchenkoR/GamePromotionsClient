using GamePromotionsClient.Models;
using GamePromotionsClient.Services;
using GamePromotionsClient.Services.Implementations;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePromotionsClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var eventService = serviceProvider.GetService<IEventService>();
            var offerService = serviceProvider.GetService<IOfferService>();
            var app = new Application(eventService, offerService);
            await app.Run();


            Console.ReadKey();
        }



        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IOfferService, OfferService>();
        }
    }
}
