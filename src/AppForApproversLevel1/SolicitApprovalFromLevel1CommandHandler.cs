using AppCommon;
using MyMessages;
using NServiceBus;

namespace AppForApproversLevel1
{
    public class SolicitApprovalFromLevel1CommandHandler : IHandleMessages<SolicitApprovalFromLevel1Command>
    {
        public Context<ItemViewModel> Context { get; set; }

        public void Handle(SolicitApprovalFromLevel1Command message)
        {
            Context.MarshalToUiThread(() => HandleOnUiThread(message));
        }

        private void HandleOnUiThread(SolicitApprovalFromLevel1Command message)
        {
            var item = new ItemViewModel
            {
                RequestId = message.RequestId,
                Description = message.Description,
                Cost = message.Cost
            };

            Context.Items.Add(item);
        }
    }
}
