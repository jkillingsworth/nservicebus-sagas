using System;
using NServiceBus;

namespace MyMessages
{
    public class ApproveRequestCommand : ICommand
    {
        public Guid RequestId { get; set; }
        public Approver Approver { get; set; }
    }
}
