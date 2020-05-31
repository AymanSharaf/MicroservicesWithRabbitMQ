using MicroservicesWithRabbitMQ.Banking.Data.Context;
using MicroservicesWithRabbitMQ.Banking.Domain.Interfaces;
using MicroservicesWithRabbitMQ.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicesWithRabbitMQ.Banking.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _context;

        public AccountRepository(BankingDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Account> GetAccounts()
        {
          return  _context.Accounts.ToList();
        }
    }
}
