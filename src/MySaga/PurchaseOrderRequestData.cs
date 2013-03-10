using System;
using NServiceBus.Saga;

namespace MySaga
{
    public class PurchaseOrderRequestData : IContainSagaData
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }

        [Unique]
        public Guid RequestId { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public bool RequiresApprovalByLevel1 { get; set; }
        public bool RequiresApprovalByLevel2 { get; set; }
        public bool ApprovedByLevel1 { get; set; }
        public bool ApprovedByLevel2 { get; set; }
    }
}
