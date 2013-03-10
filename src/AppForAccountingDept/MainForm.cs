using System.ComponentModel;
using System.Windows.Forms;

namespace AppForAccountingDept
{
    public partial class MainForm : Form
    {
        public MainForm(BindingList<ItemViewModel> items)
        {
            InitializeComponent();
            bindingSource.DataSource = items;
        }
    }
}
