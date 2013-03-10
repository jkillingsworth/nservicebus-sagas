using AppCommon;

namespace AppForAccountingDept
{
    public class ItemViewModel : ViewModel
    {
        private string purchaseOrderNumber;
        private decimal amount;
        private string description;

        public string PurchaseOrderNumber
        {
            get { return purchaseOrderNumber; }
            set
            {
                purchaseOrderNumber = value;
                NotifyChanged("PurchaseOrderNumber");
            }
        }

        public decimal Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                NotifyChanged("Amount");
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
    }
}
