using System.Linq;
using AppCommon;
using MyMessages;
using NServiceBus;

namespace AppForSubmittingRequests
{
    public class SubmitRequestReplyMessageHandler : IHandleMessages<SubmitRequestReplyMessage>
    {
        public Context<ItemViewModel> Context { get; set; }

        public void Handle(SubmitRequestReplyMessage message)
        {
            Context.MarshalToUiThread(() => HandleOnUiThread(message));
        }

        private void HandleOnUiThread(SubmitRequestReplyMessage message)
        {
            var item = Context.Items.Single(x => x.RequestId == message.RequestId);
            item.Status = message.Approved ? "Approved" : "Denied";
            item.PurchaseOrderNumber = message.PurchaseOrderNumber;
        }
    }
}
