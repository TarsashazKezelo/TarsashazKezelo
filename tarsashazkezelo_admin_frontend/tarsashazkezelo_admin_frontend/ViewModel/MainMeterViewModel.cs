using System;
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
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    public class MainMeterViewModel:ViewModelBase
    {
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
            if (Services.Count>0 && SelectedService!=null)
            {
                MainMeter newMainMeter = new MainMeter();
                Messenger.Default.Send(new NotificationMessage("AddMainMeterWindow"));
                Messenger.Default.Send(newMainMeter, "AddMainMeter");
            }
            else
            {
                MessageBox.Show("Nincs szolgáltatás kiválasztva");
            }
        }

        public MainMeterViewModel()
        {
            Services=new ObservableCollection<Service>() {};
            AddMainMeterCommand = new RelayCommand(AddMainMeterMethod);
            Messenger.Default.Register<MainMeter>(this, "AddMainMeterOKButton", (mainMeter) =>
            {
                SelectedService.MainMeters.Add(mainMeter);
            });
            Messenger.Default.Register<Service>(this, "ServiceAdded", (service) =>
            {
                Services.Add(service);
            });
        }
    }
}
