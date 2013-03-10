using System;
using NServiceBus;

namespace MyMessages
{
    public interface IRequestExpiredEvent : IEvent
    {
        Guid RequestId { get; set; }
    }
}
