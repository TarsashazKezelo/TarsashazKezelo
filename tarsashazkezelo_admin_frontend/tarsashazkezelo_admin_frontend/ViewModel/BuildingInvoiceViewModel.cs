using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Interfaces;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    public class BuildingInvoiceViewModel : ViewModelBase
    {

        IAdminFunctions _adminFunctions = new AdminFunctions();
        public ObservableCollection<Service> Services { get; private set; }

        private Service _selectedService;

        public Service SelectedService
        {
            get { return _selectedService; }
            set { Set(ref _selectedService, value); }
        }

        private MainMeter _selectedMainMeter;

        public MainMeter SelectedMainMeter
        {
            get { return _selectedMainMeter; }
            set { Set(ref _selectedMainMeter, value); }
        }

        public ICommand AddBuildingInvoiceCommand { get; private set; }

        public void AddBuildingInvoiceMethod()
        {
            if (Services.Count > 0 && SelectedService != null)
            {
                if (SelectedMainMeter != null)
                {
                    if (!SelectedMainMeter.BuildingInvoice.Valid)
                    {
                        Messenger.Default.Send<BuildingInvoice>(SelectedMainMeter.BuildingInvoice, "AddBuildingInvoiceWindow");
                    }
                    else
                    {
                        MessageBox.Show("Már tartozik épületszámla ehhez a főóraálláshoz");
                    }
                }
                else
                {
                    MessageBox.Show("Nincs főóra állás kiválasztva");
                }
            }
            else
            {
                MessageBox.Show("Nincs szolgáltatás kiválasztva");
            }
        }

        public ICommand PrintBuildingInvoiceCommand { get; private set; }

        public void PrintBuildingInvoiceMethod()
        {
            PrintDialog pd = new PrintDialog();
            
            if (pd.ShowDialog() == true)
            {
                pd.PrintDocument(FlowDocumentGenerator.GetPaginator(
                FlowDocumentGenerator.GenerateDocFromBuildingInvoice(SelectedMainMeter.BuildingInvoice, SelectedService.Name)), "Épületszámla");
            }
        }

        public BuildingInvoiceViewModel()
        {
            PrintBuildingInvoiceCommand=new RelayCommand(PrintBuildingInvoiceMethod);
            AddBuildingInvoiceCommand = new RelayCommand(AddBuildingInvoiceMethod);
            Services = _adminFunctions.GetServices();
            foreach (Service service in Services)
            {
                service.MainMeters = _adminFunctions.GetMainMetersByService(service);
                foreach (MainMeter mainMeter in service.MainMeters)
                {
                    mainMeter.BuildingInvoice =
                        _adminFunctions.GetBuildingInvoicesByService(service).SingleOrDefault(x => x.MainMeterID == mainMeter.ID);
                    if (mainMeter.BuildingInvoice==null)
                    {
                        mainMeter.BuildingInvoice=new BuildingInvoice();
                    }
                }
            }
            Messenger.Default.Register<Service>(this, "PassService", (service) =>
            {
                Services.Add(service);
            });
            Messenger.Default.Register<BuildingInvoice>(this, "BuildingInvoiceAdded", (buildingInvoice) =>
            {
                buildingInvoice.MainMeterID = SelectedMainMeter.ID;
                _adminFunctions.AddBuildingInvoice(buildingInvoice);
                BuildingInvoice bi = _adminFunctions.GetBuildingInvoicesByService(SelectedService).SingleOrDefault(x => x.MainMeterID == SelectedMainMeter.ID);
                SelectedMainMeter.BuildingInvoice = bi;
                bi.Valid = true;
                Messenger.Default.Send(new NotificationMessage("RefreshInvoices"));
            });
            Messenger.Default.Register<NotificationMessage>(this, (msg) =>
            {
                if (msg.Notification == "ClearDB")
                {
                    Services.Clear();
                }
            });
        }
    }
}
