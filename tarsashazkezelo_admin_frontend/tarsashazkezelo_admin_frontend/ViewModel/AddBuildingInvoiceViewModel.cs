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
    public class AddBuildingInvoiceViewModel:ViewModelBase
    {
        private BuildingInvoice _newBuildingInvoice;

        public BuildingInvoice NewBuildingInvoice
        {
            get { return _newBuildingInvoice; }
            set { Set(ref _newBuildingInvoice, value); }
        }

        public ICommand OkButtonCommand { get; private set; }

        public void OkButtonMethod()
        {
            Messenger.Default.Send<BuildingInvoice>(NewBuildingInvoice, "AddBuildingInvoiceOKButton");
        }

        public ICommand CancelButtonCommand { get; private set; }

        public void CancelButtonMethod()
        {
            Messenger.Default.Send(new NotificationMessage("AddBuildingInvoiceClose"));
        }

        public AddBuildingInvoiceViewModel()
        {
            OkButtonCommand=new RelayCommand(OkButtonMethod);
            CancelButtonCommand=new RelayCommand(CancelButtonMethod);
            Messenger.Default.Register<BuildingInvoice>(this, "AddBuildingInvoice", (buildingInvoice) =>
            {
                NewBuildingInvoice = buildingInvoice;
            });
        }

    }
}
