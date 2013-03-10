using System;
using NServiceBus;

namespace MyMessages
{
    public class SubmitRequestCommand : ICommand
    {
        public Guid RequestId { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
