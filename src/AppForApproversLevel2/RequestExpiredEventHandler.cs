using System.Linq;
using AppCommon;
using MyMessages;
using NServiceBus;

namespace AppForApproversLevel2
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
            var item = Context.Items.SingleOrDefault(x => x.RequestId == message.RequestId);
            Context.Items.Remove(item);
        }
    }
}
