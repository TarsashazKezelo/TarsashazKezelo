﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Interfaces;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{

    public class MainMeterViewModel : ViewModelBase
    {
        private IAdminFunctions _adminFunctions;

        public ObservableCollection<Service> Services { get; }

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

        public ICommand AddMainMeterCommand { get; private set; }

        public void AddMainMeterMethod()
        {
            if (Services.Count > 0 && SelectedService != null)
            {
                MainMeter newMainMeter = new MainMeter() { ServiceID = SelectedService.ID };
                Messenger.Default.Send(newMainMeter, "AddMainMeterWindow");
            }
            else
            {
                MessageBox.Show("Nincs szolgáltatás kiválasztva");
            }
        }

        public MainMeterViewModel()
        {
            _adminFunctions = new AdminFunctions();
            Services = _adminFunctions.GetServices();
            foreach (Service service in Services)
            {
                service.MainMeters = _adminFunctions.GetMainMetersByService(service);
            }
            AddMainMeterCommand = new RelayCommand(AddMainMeterMethod);
            Messenger.Default.Register<MainMeter>(this, "MainMeterAdded", (mainMeter) =>
            {
                if (SelectedService.MainMeters.Count == 0)
                {
                    _adminFunctions.AddMainMeter(mainMeter);
                    MainMeter mm = _adminFunctions.GetMainMetersByService(SelectedService).Last();
                    SelectedService.MainMeters.Add(mm);
                    Messenger.Default.Send(mm, "PassMainMeter");
                }
                else
                {
                    if (SelectedService.MainMeters.Last().Reading<mainMeter.Reading)
                    {
                        _adminFunctions.AddMainMeter(mainMeter);
                        MainMeter mm = _adminFunctions.GetMainMetersByService(SelectedService).Last();
                        SelectedService.MainMeters.Add(mm);
                        Messenger.Default.Send(mm, "PassMainMeter");
                    }
                    else
                    {
                        MessageBox.Show("A megadott óraállás kisebb mint a legutolsó óraállás");
                    }
                }
            });
            Messenger.Default.Register<NotificationMessage>(this, (msg) =>
            {
                if (msg.Notification == "ClearDB")
                {
                    Services.Clear();
                }
            });
            Messenger.Default.Register<Service>(this, "PassService", (service) =>
            {
                Services.Add(service);
                service.MainMeters = _adminFunctions.GetMainMetersByService(service);
            });
        }
    }
}
