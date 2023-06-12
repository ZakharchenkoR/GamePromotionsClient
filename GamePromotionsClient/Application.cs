using GamePromotionsClient.Common;
using GamePromotionsClient.Hubs;
using GamePromotionsClient.Services;
using System;
using System.Threading.Tasks;

namespace GamePromotionsClient
{
    public class Application
    {
        private readonly IEventService _eventService;
        private readonly IOfferService _offerService;
        private readonly GameHub _gameHub;
        private bool isAppRunning = true;

        public Application(IEventService eventService, IOfferService offerService)
        {
            _eventService = eventService;
            _offerService = offerService;
            _gameHub = new GameHub();
        }

        public async Task Run()
        {
            await _gameHub.RunServerListener();

            do
            {
                Console.Clear();
                Console.WriteLine("Press 1 to get data, or 2 to exit.");
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Getting information about promotions...");
                        await GetPromotionsInformation();
                        Console.WriteLine("Please press any button to continue...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("Exiting the application...");
                        isAppRunning = false;
                        await _gameHub.StopServerListener();
                        Environment.Exit(0);
                        return;

                    default:
                        Console.WriteLine("Invalid option, please choose 1 or 2.");
                        break;
                }
            } while (isAppRunning);
        }

        private async Task GetPromotionsInformation()
        {
            var eventsTask = _eventService.GetEvents();
            var offersTask = _offerService.GetOffers();
            await Task.WhenAll(eventsTask, offersTask);

            var events = eventsTask.Result;
            Console.WriteLine("Available events");
            Console.WriteLine();
            foreach (var evnt in events)
            {
                Printer.Print(evnt);
            }

            var offers = offersTask.Result;
            Console.WriteLine("Available offers");
            Console.WriteLine();
            foreach (var offer in offers)
            {
                Printer.Print(offer);
            }
        }
    }
}
