using System;
using System.ComponentModel;
using System.Windows.Forms;
using AppCommon;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using NServiceBus;
using NServiceBus.Installation.Environments;

namespace AppForApproversLevel2
{
    static class Program
    {
        static void StartupAction()
        {
            Configure.Instance.ForInstallationOn<Windows>().Install();
        }

        [STAThread]
        static void Main()
        {
            var container = new UnityContainer();
            var locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

            Configure.With()
                .UnityBuilder(container)
                .UseTransport<Msmq>()
                .DisableTimeoutManager()
                .UnicastBus()
                .CreateBus()
                .Start(StartupAction);

            var items = new BindingList<ItemViewModel>();
            var appForm = new MainForm(items);
            var context = new Context<ItemViewModel> { Items = items, AppForm = appForm };
            container.RegisterInstance(context);

            Application.EnableVisualStyles();
            Application.Run(context.AppForm);
        }
    }
}
