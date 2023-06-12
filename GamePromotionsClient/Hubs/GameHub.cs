using GamePromotionsClient.Common;
using GamePromotionsClient.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GamePromotionsClient.Hubs
{
    public class GameHub
    {
        private HubConnection _connection;

        public GameHub()
        {
            SetConnection();
        }

        public async Task RunServerListener()
        {
            try
            {
                _connection.On<OfferModel>("ReceiveOffer", (offer) =>
                {
                    Console.WriteLine("New active offer");
                    Printer.Print(offer);
                });

                _connection.On<EventModel>("ReceiveEvent", (evnt) =>
                {
                    Console.WriteLine("New active event");
                    Printer.Print(evnt);
                });

                await _connection.StartAsync();

                Console.WriteLine("Connected to server. Waiting for offers and events...");
                Console.WriteLine("Please press any button to continue...");

                Console.ReadKey();
            }catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task StopServerListener()
        {
            await _connection.StopAsync();
        }

        private void SetConnection()
        {
            var config = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("config.json"));
            string url = $"{config["ApiUrl"]}/gamehub";

            _connection = new HubConnectionBuilder()
            .WithUrl(url, options =>
            {
                options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
            })
            .WithAutomaticReconnect()
            .Build();
        }
    }
}
