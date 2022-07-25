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

        public async Task SendMessage<T>(T message, string exchange, string routingKey)
        {
            var factory = new ConnectionFactory { HostName = _configuration["RabbitMQ:HostName"] };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: exchange,
                                    type: "topic", 
                                    durable: true, 
                                    autoDelete: false, 
                                    arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: exchange, routingKey: routingKey, body: body);

            connection.Close();
        }
    }
}