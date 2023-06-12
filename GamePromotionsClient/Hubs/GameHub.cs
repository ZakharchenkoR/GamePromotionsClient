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

        public async Task RunServerListener(int retryCount = 25)
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

            int counter = 0;
            while (counter < retryCount)
            {
                try
                {
                    await _connection.StartAsync();

                    Console.WriteLine("Successfully connected to the remote server...");
                    Console.WriteLine("Please press any button to continue...");

                    Console.ReadKey();
                    break;
                }
                catch
                {
                    Console.WriteLine("No connection to the remote server... retrying in 5 seconds");
                    await Task.Delay(5000);
                    counter++;
                }
            }

            if (counter == retryCount)
            {
                Console.WriteLine("Maximum retry attempts reached. Please check your network connection.");
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
