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
    /// Interaction logic for AddMeterWindow.xaml
    /// </summary>
    public partial class AddMeterWindow : Window
    {
        public AddMeterWindow(Meter m)
        {
            InitializeComponent();
            Messenger.Default.Send(m, "AddMeter");
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Register<Meter>(this, "AddMeterOKButton", (meter) =>
            {
                Close();
                Messenger.Default.Send(meter, "MeterAdded");
                Messenger.Default.Unregister<Meter>(this, "AddMeterOKButton");
                Messenger.Default.Unregister<NotificationMessage>(this, NotificationMessageReceived);
            });
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "AddMeterClose")
            {
                Close();
                Messenger.Default.Unregister<Meter>(this, "AddMeterOKButton");
                Messenger.Default.Unregister<NotificationMessage>(this, NotificationMessageReceived);
            }
        }
    }
}
