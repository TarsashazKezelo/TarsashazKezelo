using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Interfaces;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    public class AddMeterViewModel : ViewModelBase
    {
        private IAdminFunctions _adminFunctions=new AdminFunctions();
        public ObservableCollection<Service> Services { get; }

        private Service _selectedService;

        public Service SelectedService
        {
            get { return _selectedService; }
            set { Set(ref _selectedService, value); }
        }

        private Meter _newMeter;

        public ICommand OkButtonCommand { get; private set; }

        public void OkButtonMethod()
        {
            _newMeter.ServiceID = SelectedService.ID;
            Messenger.Default.Send(_newMeter, "AddMeterOKButton");
        }

        public ICommand CancelButtonCommand { get; private set; }

        public void CancelButtonMethod()
        {
            Messenger.Default.Send(new NotificationMessage("AddMeterClose"));
        }

        public AddMeterViewModel()
        {
            OkButtonCommand = new RelayCommand(OkButtonMethod);
            CancelButtonCommand = new RelayCommand(CancelButtonMethod);
            Services = _adminFunctions.GetServices();
            Messenger.Default.Register<Meter>(this, "AddMeter", (meter) =>
            {
                _newMeter = meter;
            });
        }

    }
}
