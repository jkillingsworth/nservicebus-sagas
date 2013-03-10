using System;
using NServiceBus;

namespace MyMessages
{
    public class DenyRequestCommand : ICommand
    {
        public Guid RequestId { get; set; }
    }
}
