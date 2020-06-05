using MediatR;
using MicroservicesWithRabbitMQ.Banking.Application.Interfaces;
using MicroservicesWithRabbitMQ.Banking.Application.Services;
using MicroservicesWithRabbitMQ.Banking.Data.Context;
using MicroservicesWithRabbitMQ.Banking.Data.Repositories;
using MicroservicesWithRabbitMQ.Banking.Domain.CommandHandlers;
using MicroservicesWithRabbitMQ.Banking.Domain.Commands;
using MicroservicesWithRabbitMQ.Banking.Domain.Interfaces;
using MicroservicesWithRabbitMQ.Domain.Core.Bus;
using MicroservicesWithRabbitMQ.Infrastructure.Bus;
using MicroservicesWithRabbitMQ.Transfer.Application.Interfaces;
using MicroservicesWithRabbitMQ.Transfer.Application.Services;
using MicroservicesWithRabbitMQ.Transfer.Data.Repositories;
using MicroservicesWithRabbitMQ.Transfer.Domain.EventHandlers;
using MicroservicesWithRabbitMQ.Transfer.Domain.Events;
using MicroservicesWithRabbitMQ.Transfer.Domain.Interfaces;
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
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp=> 
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(),scopeFactory);
            
            });

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Application Services
            services.AddTransient<IAccountService, AccountService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();

        }

        public static void RegisterTranferServices(IServiceCollection services) 
        {
            // Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);

            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            // Domain Transfer Commands

            // Application Services
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<ITransferRepository, TransferRepository>();

            services.AddTransient<TransferDbContext>();

        }
    }
}
