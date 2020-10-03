using System;
using System.Net.WebSockets;
using Websocket.Client;

namespace Client
{
    class Program
    {
        static void Main()
        {
            using var client = new WebsocketClient(new Uri("ws://localhost:5000/"));
            client.MessageReceived.Subscribe(msg => Console.WriteLine($"Message received: {msg}"));

            client.Start();

            client.Send("Hello world!");

            Console.ReadKey();

            client.Stop(WebSocketCloseStatus.NormalClosure, "Status");
        }
    }
}
