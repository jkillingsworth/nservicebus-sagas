using System.Linq;
using AppCommon;
using MyMessages;
using NServiceBus;

namespace AppForSubmittingRequests
{
    public class RequestExpiredEventHandler : IHandleMessages<IRequestExpiredEvent>
    {
        public Context<ItemViewModel> Context { get; set; }

        public void Handle(IRequestExpiredEvent message)
        {
            Context.MarshalToUiThread(() => HandleOnUiThread(message));
        }

        private void HandleOnUiThread(IRequestExpiredEvent message)
        {
            var item = Context.Items.Single(x => x.RequestId == message.RequestId);
            item.Status = "Expired";
        }
    }
}
