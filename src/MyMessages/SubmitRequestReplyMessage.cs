using System;
using NServiceBus;

namespace MyMessages
{
    public class SubmitRequestReplyMessage : IMessage
    {
        public Guid RequestId { get; set; }
        public bool Approved { get; set; }
        public string PurchaseOrderNumber { get; set; }
    }
}
