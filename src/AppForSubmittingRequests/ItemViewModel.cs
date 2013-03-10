using System;
using AppCommon;

namespace AppForSubmittingRequests
{
    public class ItemViewModel : ViewModel
    {
        private Guid requestId;
        private string description;
        private decimal cost;
        private string status;
        private string purchaseOrderNumber;

        public Guid RequestId
        {
            get { return requestId; }
            set
            {
                requestId = value;
                NotifyChanged("RequestId");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyChanged("Description");
            }
        }

        public decimal Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                NotifyChanged("Cost");
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                NotifyChanged("Status");
            }
        }

        public string PurchaseOrderNumber
        {
            get { return purchaseOrderNumber; }
            set
            {
                purchaseOrderNumber = value;
                NotifyChanged("PurchaseOrderNumber");
            }
        }
    }
}
