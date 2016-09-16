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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<BuildingInvoice>(this, "AddBuildingInvoiceWindow", (buildingInvoice) =>
            {
                var addBuildingInvoice=new AddBuildingInvoiceWindow(buildingInvoice);
                addBuildingInvoice.ShowDialog();
            });
            Messenger.Default.Register<Service>(this, "AddServiceWindow", (service) =>
            {
                var addService = new AddServiceWindow(service);
                addService.ShowDialog();
            });
            Messenger.Default.Register<MainMeter>(this, "AddMainMeterWindow", (mainMeter) =>
            {
                var addMainMeter = new AddMainMeterWindow(mainMeter);
                addMainMeter.ShowDialog();
            });
            Messenger.Default.Register<Meter>(this, "AddMeterWindow", (meter) =>
            {
                var addMeter = new AddMeterWindow(meter);
                addMeter.ShowDialog();
            });
        }
    }
}
