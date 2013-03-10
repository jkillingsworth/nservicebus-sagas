using System;
using AppCommon;

namespace AppForApproversLevel2
{
    public class ItemViewModel : ViewModel
    {
        private Guid requestId;
        private string description;
        private decimal cost;

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
    }
}
