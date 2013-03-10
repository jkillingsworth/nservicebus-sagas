using System.Threading;
using AppCommon;
using MyMessages;
using NServiceBus;

namespace AppForAccountingDept
{
    public class RecordEncumbranceCommandHandler : IHandleMessages<RecordEncumbranceCommand>
    {
        private static int purchaseOrderCounter = 0;

        public Context<ItemViewModel> Context { get; set; }

        public IBus Bus { get; set; }

        public void Handle(RecordEncumbranceCommand message)
        {
            var purchaseOrderNumber = GetNextPurchaseOrderNumber();

            var item = new ItemViewModel
            {
                PurchaseOrderNumber = purchaseOrderNumber,
                Amount = message.Cost,
                Description = message.Description
            };

            var reply = new RecordEncumbranceReplyMessage
            {
                PurchaseOrderNumber = purchaseOrderNumber
            };

            Context.MarshalToUiThread(() => Context.Items.Add(item));
            Bus.Reply(reply);
        }

        private static string GetNextPurchaseOrderNumber()
        {
            Interlocked.Increment(ref purchaseOrderCounter);
            return string.Format("PO-A{0:D4}", purchaseOrderCounter);
        }
    }
}
