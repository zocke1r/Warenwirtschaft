using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;
using MQTTClient.Data;
using System.Configuration;

namespace MQTTClient.Client
{
    class Client
    {
        // Lazyload client
        IMqttClient mqttClient;

        public bool IsConnected => mqttClient.IsConnected;

        private string str_ClientID = "ApplikationClient";

        // Constructor
        public Client()
        {
            Start();
        }

        private void GetConfiguration()
        {
            
        }

        async void Start()
        {

            mqttClient = new MqttFactory().CreateMqttClient();

            string clientId = "Client1";

            var options = new MqttClientOptionsBuilder()
                .WithClientId(clientId)

                .WithTcpServer("127.0.0.1", 1884)
                .WithWillMessage(new MqttApplicationMessageBuilder().WithTopic("test").WithPayload($"{clientId} ist Tot!! :(").Build())
                .WithCleanSession()
                .Build();
            await mqttClient.ConnectAsync(options);

            mqttClient.ApplicationMessageReceived += (s, e) =>
            {
                Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                Console.WriteLine();
            };

        }

        // Publishes message to specific topic
        public void publish(Message _Message)
        {
            mqttClient.PublishAsync(new MqttApplicationMessageBuilder().WithPayload(_Message._Message).WithTopic(_Message.str_TopicName).Build());
        }


        public async void SubscribeAsync()
        {
            Console.WriteLine("### CONNECTED WITH SERVER ###");

            // Subscribe to a topic
            await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("test").Build());

            Console.WriteLine("### SUBSCRIBED ###");
        }


    }
}
