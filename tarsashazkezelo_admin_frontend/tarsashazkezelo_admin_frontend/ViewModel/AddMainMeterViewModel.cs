using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    public class AddMainMeterViewModel : ViewModelBase
    {
        private MainMeter _newMainMeter;

        public MainMeter NewMainMeter
        {
            get { return _newMainMeter; }
            set { Set(ref _newMainMeter, value); }
        }

        public ICommand OkButtonCommand { get; private set; }

        public void OkButtonMethod()
        {
            Messenger.Default.Send(NewMainMeter, "AddMainMeterOKButton");
            Messenger.Default.Send(new NotificationMessage("AddMainMeterClose"));
        }

        public ICommand CancelButtonCommand { get; private set; }

        public void CancelButtonMethod()
        {
            Messenger.Default.Send(new NotificationMessage("AddMainMeterClose"));
        }

        public AddMainMeterViewModel()
        {
            OkButtonCommand = new RelayCommand(OkButtonMethod);
            CancelButtonCommand = new RelayCommand(CancelButtonMethod);
            Messenger.Default.Register<MainMeter>(this, "AddMainMeter", (mainMeter) =>
            {
                NewMainMeter = mainMeter;
            });
        }
    }
}
