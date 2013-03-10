using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AppCommon
{
    public class Context<T> where T : ViewModel
    {
        public BindingList<T> Items { get; set; }
        public Form AppForm { get; set; }

        public void MarshalToUiThread(Action action)
        {
            if (AppForm.InvokeRequired)
            {
                AppForm.Invoke(action);
            }
            else
            {
                action.Invoke();
            }
        }
    }
}
