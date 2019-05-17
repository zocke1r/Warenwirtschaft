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
using Schuhladen_WW.DataLayer.Mapping;
using Schuhladen_WW.DataLayer;
using System.Threading;

namespace MQTTClient.Client
{
    public class Client
    {
        // Lazyload client
        IMqttClient mqttClient;

        public bool IsConnected => mqttClient.IsConnected;

        private string str_ClientID;
        private string str_IpAdress;
        private string str_PortAdress;

        // Constructor
        public Client()
        {
            str_ClientID = ConfigurationManager.AppSettings["Client_Id"];
            str_IpAdress = ConfigurationManager.AppSettings["IP_Adress"];
            str_PortAdress = ConfigurationManager.AppSettings["Port_Adress"];

            if (str_ClientID != "" && str_IpAdress != "" && str_PortAdress != "")
            {
                Start();
            }
        }

        public async void Start()
        {

            mqttClient = new MqttFactory().CreateMqttClient();

            var options = new MqttClientOptionsBuilder()

                // Set client ID for app
                .WithClientId(str_ClientID)

                // Set ip adress & port to send messages to
                .WithTcpServer(str_IpAdress, Convert.ToInt32(str_PortAdress))

                .WithWillMessage(new MqttApplicationMessageBuilder().WithTopic("Died").WithPayload($"{str_ClientID} ist Tot!! :(").Build())

                .WithCleanSession()

                .Build();

            await mqttClient.ConnectAsync(options);
            

            // Logic for Client
            mqttClient.ApplicationMessageReceived += (s, e) =>
            {
                Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                Console.WriteLine($"+ ClientID = {e.ClientId}");
                Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");

                // Get Credentials
                string str_TmpPayload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                string[] str_ClientIdSender = str_TmpPayload.Split(';');

                // Topic REGISTER
                if (e.ApplicationMessage.Topic == "Register" && str_ClientIdSender[0] != this.str_ClientID)
                {
                    // Get all available Displays
                    List<Stellplatz> __Stellplatz = DataController.ReturnStellplatz();

                    // Tmp bool
                    bool bool_IsRegistered = false;

                    foreach (Stellplatz Item in __Stellplatz)
                    {
                        if (Item.str_Bezeichnung == str_ClientIdSender[0])
                        {
                            bool_IsRegistered = true;
                            Message _msg = new Message();
                            _msg.str_TopicName = "AknowledgeRegister";
                            _msg._Message = Item.str_Bezeichnung;
                            publish(_msg);

                            // Reasign price after restart
                            foreach (StellplatzArtikel Items in DataController.ReturnStellplatzArtikel())
                            {
                                if (Item.int_Id == Items.int_StellplatzID)
                                {
                                    _msg.str_TopicName = Item.str_Bezeichnung;
                                    foreach (Live_Artikel article in DataController.ReturnLiveArtikel())
                                    {
                                        if (article.int_ID == Items.int_ArtikelID)
                                        {
                                            _msg._Message = article.dbl_SellPrice.ToString();
                                            Thread.Sleep(250);
                                            publish(_msg);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Check if exists
                    if (!bool_IsRegistered)
                    {
                        Stellplatz _Stellplatz = new Stellplatz();

                        // Generate unique client_Id
                        _Stellplatz.str_Bezeichnung = CreateClientId(str_ClientIdSender[0]);
                        _Stellplatz.str_MacAdress = str_ClientIdSender[1];

                        _Stellplatz.Insert();

                        DataController.CreateDataLayer();
                        bool_IsRegistered = false;

                        Message _msg = new Message();
                        _msg.str_TopicName = "AknowledgeRegister";
                        _msg._Message = _Stellplatz.str_Bezeichnung;

                        SubscribeAsync(_msg);

                        publish(_msg);

                        _msg.str_TopicName = _Stellplatz.str_Bezeichnung + "/delete";
                        SubscribeAsync(_msg);
                    }
                }
            };

        }

        // Publishes message to specific topic
        public void publish(Message _Message)
        {
            mqttClient.PublishAsync(new MqttApplicationMessageBuilder().WithPayload(_Message._Message).WithTopic(_Message.str_TopicName).Build());
        }

        public async void SubscribeAsyncInitial()
        {
            Console.WriteLine("### CONNECTED WITH SERVER ###");

            // Subscribe to a topic
            await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("Register").Build());

            Console.WriteLine("### SUBSCRIBED ###");
        }

        public async void SubscribeAsync(Message _msg)
        {
            // Subscribe to a topic
            await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic(_msg.str_TopicName).Build());
        }

        private string CreateClientId(string str_InitialClientId)
        {
            Random _Random = new Random();
            int int_RandomIdentifier = _Random.Next(100000, 10000000);
            str_InitialClientId = str_InitialClientId + "_" + int_RandomIdentifier.ToString();
            return str_InitialClientId;
        }


    }
}
