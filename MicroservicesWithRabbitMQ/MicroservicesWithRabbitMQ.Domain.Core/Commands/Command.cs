﻿using MicroservicesWithRabbitMQ.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicesWithRabbitMQ.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeStamp { get; protected set; }
        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
