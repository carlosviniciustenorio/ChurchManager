using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ChurchManager.Infrastructure.RabbitMQ
{
    public class RabbitMQProducer : IMessageProducer
    {
        private readonly IConfiguration _configuration;

        public RabbitMQProducer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage<T>(T message, string routingKey)
        {
            var hostName = _configuration["RabbitMQ:HostName"];
            var factory = new ConnectionFactory { HostName = hostName };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "eventbus.church",
                                    type: "topic", 
                                    durable: true, 
                                    autoDelete: false, 
                                    arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "topicProducer", routingKey: routingKey, body: body);

            connection.Close();
        }
    }
}