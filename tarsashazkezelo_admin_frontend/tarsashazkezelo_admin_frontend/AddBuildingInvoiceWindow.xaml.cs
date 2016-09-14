using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend
{
    /// <summary>
    /// Interaction logic for AddBuildingInvoiceWindow.xaml
    /// </summary>
    public partial class AddBuildingInvoiceWindow : Window
    {
        public AddBuildingInvoiceWindow(BuildingInvoice bi)
        {
            InitializeComponent();
            Messenger.Default.Send<BuildingInvoice>(bi, "AddBuildingInvoice");
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Register<BuildingInvoice>(this, "AddBuildingInvoiceOKButton", (buildingInvoice) =>
            {
                Close();
                Messenger.Default.Send(buildingInvoice, "BuildingInvoiceAdded");
            });
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "AddBuildingInvoiceClose")
            {
                Close();
            }
        }

    }
}
