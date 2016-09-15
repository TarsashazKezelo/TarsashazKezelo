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
    /// Interaction logic for AddMainMeterWindow.xaml
    /// </summary>
    public partial class AddMainMeterWindow : Window
    {
        public AddMainMeterWindow(MainMeter mm)
        {
            InitializeComponent();
            Messenger.Default.Send(mm, "AddMainMeter");
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Register<MainMeter>(this, "AddMainMeterOKButton", (mainMeter) =>
            {
                Close();
                Messenger.Default.Send(mainMeter, "MainMeterAdded");
            });
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "AddMainMeterClose")
            {
                this.Close();
            }
        }
    }
}
