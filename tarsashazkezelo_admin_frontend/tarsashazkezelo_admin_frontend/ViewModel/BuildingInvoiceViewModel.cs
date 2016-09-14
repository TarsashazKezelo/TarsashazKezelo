﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Interfaces;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    public class BuildingInvoiceViewModel : ViewModelBase
    {
        IAdminFunctions _adminFunctions=new AdminFunctions();
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
                if (SelectedMainMeter!=null)
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
                MainMeter newMainMeter = new MainMeter();
                Messenger.Default.Send(new NotificationMessage("AddMainMeterWindow"));
                Messenger.Default.Send(newMainMeter, "AddMainMeter");
            }
            else
            {
                MessageBox.Show("Nincs szolgáltatás kiválasztva");
            }
        }

        public BuildingInvoiceViewModel()
        {
            Services = _adminFunctions.GetServices();
            foreach (Service service in Services)
            {
                service.MainMeters = _adminFunctions.GetMainMetersByService(service);
            }
            Messenger.Default.Register<Service>(this, "ServiceAdded", (service) =>
            {
                Services.Add(service);
            });
            Messenger.Default.Register<MainMeter>(this, "MainMeterAdded", (mainMeter) =>
            {
                Service s = Services.SingleOrDefault(x => x.ID == mainMeter.ServiceID);
                s.MainMeters.Add(mainMeter);
            });
            Messenger.Default.Register<BuildingInvoice>(this, "BuildingInvoiceAdded", (buildingInvoice) =>
            {
                _adminFunctions.AddBuildingInvoice(buildingInvoice);
                SelectedMainMeter.BuildingInvoice = buildingInvoice;
                buildingInvoice.Valid = true;
            });
        }
    }
}