using MicroservicesWithRabbitMQ.Banking.Application.Interfaces;
using MicroservicesWithRabbitMQ.Banking.Application.Models;
using MicroservicesWithRabbitMQ.Banking.Domain.Commands;
using MicroservicesWithRabbitMQ.Banking.Domain.Interfaces;
using MicroservicesWithRabbitMQ.Banking.Domain.Models;
using MicroservicesWithRabbitMQ.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicesWithRabbitMQ.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _eventBus;

        public AccountService(IAccountRepository accountRepository, IEventBus eventBus)
        {
            _accountRepository = accountRepository;
            _eventBus = eventBus;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand
           (
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount

           );
            _eventBus.SendCommand(createTransferCommand);
        }
    }
}
