using System;
using System.Windows.Forms;
using AppCommon;
using Microsoft.Practices.ServiceLocation;
using MyMessages;
using NServiceBus;

namespace AppForSubmittingRequests
{
    public partial class NewRequestForm : Form
    {
        public NewRequestForm()
        {
            InitializeComponent();
        }

        private static Context<ItemViewModel> Context
        {
            get { return ServiceLocator.Current.GetInstance<Context<ItemViewModel>>(); }
        }

        private static IBus Bus
        {
            get { return ServiceLocator.Current.GetInstance<IBus>(); }
        }

        private void ButtonSubmitClick(object sender, EventArgs e)
        {
            var requestId = Guid.NewGuid();
            var description = textboxDescription.Text;

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("You must provide a valid description.");
                DialogResult = DialogResult.None;
                return;
            }

            decimal cost;
            if (!decimal.TryParse(textboxCost.Text, out cost))
            {
                MessageBox.Show("You must provide a valid cost.");
                DialogResult = DialogResult.None;
                return;
            }

            var item = new ItemViewModel
            {
                RequestId = requestId,
                Description = description,
                Cost = cost
            };

            var command = new SubmitRequestCommand
            {
                RequestId = requestId,
                Description = description,
                Cost = cost
            };

            Context.Items.Add(item);
            Bus.Send(command);

            DialogResult = DialogResult.OK;
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
