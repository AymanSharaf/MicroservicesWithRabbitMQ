using MicroservicesWithRabbitMQ.Banking.Data.Context;
using MicroservicesWithRabbitMQ.Transfer.Domain.Interfaces;
using MicroservicesWithRabbitMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicesWithRabbitMQ.Transfer.Data.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _transferDbContext;

        public TransferRepository(TransferDbContext transferDbContext)
        {
            _transferDbContext = transferDbContext;
        }
        public IEnumerable<TransferLog> GetTransfers()
        {
            return _transferDbContext.TransferLogs.ToList();
        }
    }
}
