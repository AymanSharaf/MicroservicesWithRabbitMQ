using MicroservicesWithRabbitMQ.Domain.Core.Bus;
using MicroservicesWithRabbitMQ.Infrastructure.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicesWithRabbitMQ.Infrastructure.Ioc
{
    public class DependancyContainer
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            // Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
