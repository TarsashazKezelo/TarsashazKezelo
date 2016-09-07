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
    public class AddServiceViewModel : ViewModelBase

    {
        private Service _newService;

        public Service NewService
        {
            get { return _newService; }
            set { Set(ref _newService, value); }
        }

        public ICommand OkButtonCommand { get; private set; }

        public void OkButtonMethod()
        {
            Messenger.Default.Send(NewService, "AddServiceOKButton");
            Messenger.Default.Send(new NotificationMessage("AddServiceClose"));
        }

        public ICommand CancelButtonCommand { get; private set; }

        public void CancelButtonMethod()
        {
            Messenger.Default.Send(new NotificationMessage("AddServiceClose"));
        }

        public AddServiceViewModel()
        {
            OkButtonCommand = new RelayCommand(OkButtonMethod);
            CancelButtonCommand=new RelayCommand(CancelButtonMethod);
            Messenger.Default.Register<Service>(this, "AddService", (service) =>
            {
                NewService = service;
            });
        }
    }
}
