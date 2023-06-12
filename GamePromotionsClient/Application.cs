using GamePromotionsClient.Common;
using GamePromotionsClient.Services;
using System;
using System.Threading.Tasks;

namespace GamePromotionsClient
{
    public class Application
    {
        private readonly IEventService _eventService;
        private readonly IOfferService _offerService;

        public Application(IEventService eventService, IOfferService offerService)
        {
            _eventService = eventService;
            _offerService = offerService;
        }

        public async Task Run()
        {
            var eventsTask  = _eventService.GetEvents();
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
