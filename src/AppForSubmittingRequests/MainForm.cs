using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AppForSubmittingRequests
{
    public partial class MainForm : Form
    {
        public MainForm(BindingList<ItemViewModel> items)
        {
            InitializeComponent();
            bindingSource.DataSource = items;
        }

        private void ButtonCreateRequestClick(object sender, EventArgs e)
        {
            var form = new NewRequestForm();
            form.ShowDialog();
        }
    }
}
