using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Interfaces;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    public class ServiceViewModel : ViewModelBase
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

        public ICommand AddServiceCommand { get; private set; }

        public void AddServiceMethod()
        {
            Service newService = new Service();
            Messenger.Default.Send(newService, "AddServiceWindow");
        }

        public ServiceViewModel()
        {
            _adminFunctions=new AdminFunctions();
            AddServiceCommand = new RelayCommand(AddServiceMethod);
            Messenger.Default.Register<Service>(this, "ServiceAdded", (service) =>
            {                
                _adminFunctions.AddService(service);
                Service s = _adminFunctions.GetServices().Last();
                Services.Add(s);
                Messenger.Default.Send(s, "PassService");
            });
            Services = _adminFunctions.GetServices();
            Messenger.Default.Register<NotificationMessage>(this, (msg) =>
            {
                if (msg.Notification=="InitDB")
                {
                    ObservableCollection<Service> newCollection = _adminFunctions.GetServices();
                    Services.Clear();
                    foreach (Service service in newCollection)
                    {
                        Services.Add(service);
                        Messenger.Default.Send(service, "PassService");
                    }
                }
            });
        }
    }
}
