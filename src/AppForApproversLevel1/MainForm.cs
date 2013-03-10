using System;
using System.ComponentModel;
using System.Windows.Forms;
using AppCommon;
using Microsoft.Practices.ServiceLocation;
using MyMessages;
using NServiceBus;

namespace AppForApproversLevel1
{
    public partial class MainForm : Form
    {
        public MainForm(BindingList<ItemViewModel> items)
        {
            InitializeComponent();
            bindingSource.DataSource = items;
        }

        private static Context<ItemViewModel> Context
        {
            get { return ServiceLocator.Current.GetInstance<Context<ItemViewModel>>(); }
        }

        private static IBus Bus
        {
            get { return ServiceLocator.Current.GetInstance<IBus>(); }
        }

        private void ButtonApproveClick(object sender, EventArgs e)
        {
            var item = bindingSource.Current as ItemViewModel;
            if (item == null)
            {
                MessageBox.Show("Nothing selected to approve.");
                return;
            }

            Context.Items.Remove(item);
            Bus.Send(new ApproveRequestCommand { RequestId = item.RequestId, Approver = Approver.Level1 });
        }

        private void ButtonDenyClick(object sender, EventArgs e)
        {
            var item = bindingSource.Current as ItemViewModel;
            if (item == null)
            {
                MessageBox.Show("Nothing selected to deny.");
                return;
            }

            Context.Items.Remove(item);
            Bus.Send(new DenyRequestCommand { RequestId = item.RequestId });
        }
    }
}
