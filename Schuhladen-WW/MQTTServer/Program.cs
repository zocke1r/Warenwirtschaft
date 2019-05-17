using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Server;
using System.Net;

namespace MQTTServer.Server
{
    class Program
    {
        static void Main(string[] args)
        {

            Server server = new Server();

            Console.ReadKey();

            while (true)
            {
                Console.ReadKey();
            }
        }


        class Server
        {

            IMqttServer mqttServer;

            public Server()
            {
                startServer();
            }

            public async void startServer()
            {
                var optionsBuilder = new MqttServerOptionsBuilder()
                    .WithConnectionBacklog(100)
                    .WithDefaultEndpointPort(1883)
                    .WithDefaultEndpointBoundIPAddress(IPAddress.Parse("172.22.111.55"))
                    ;
                mqttServer = new MqttFactory().CreateMqttServer();
                await mqttServer.StartAsync(optionsBuilder.Build());

                mqttServer.ClientConnected += (s, e) =>
                {
                    Console.WriteLine(e.ClientId);
                };
            }

            private void MqttServer_ClientConnected(object sender, MqttClientConnectedEventArgs e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

