using NServiceBus;

namespace MyMessages
{
    public class RecordEncumbranceReplyMessage : IMessage
    {
        public string PurchaseOrderNumber { get; set; }
    }
}
