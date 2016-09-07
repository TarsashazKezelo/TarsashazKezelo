using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Repository.Repos
{
    interface IAdminRepo
    {
        BindingList<Apartment> GetAppartments();
        void ModifyAppartment(Apartment appartment);
        ObservableCollection<BuildingInvoice> GetBuildingInvoices();
        void AddBuildingInvoice(BuildingInvoice buildingInvoice);
        ObservableCollection<Invoice> GetInvoices();
        ObservableCollection<MainMeter> GetMainMeters();
        void AddMainMeter(MainMeter mainMeter);
        ObservableCollection<Meter> GetMeters();
        void AddMeter(Meter meter);
        ObservableCollection<Service> GetServices();
        void AddService(Service service);
    }
}
