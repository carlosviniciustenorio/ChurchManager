using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchManager.Infrastructure.RabbitMQ
{
    public interface IMessageProducer
    {
        Task SendMessage<T>(T message, string exchange, string routingKey);
    }
}