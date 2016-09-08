using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.Interfaces
{
    interface IAdminFunctions
    {
        BindingList<Apartment> GetApartments();

        void ModifyApartment(Apartment a);

        void AddBuildingInvoice(BuildingInvoice bi);

        ObservableCollection<BuildingInvoice> GetBuildingInvoices();

        ObservableCollection<Invoice> GetInvoices();

        void AddMainMeter(MainMeter mm);

        ObservableCollection<MainMeter> GetMainMetersByService(Service s);

        void AddMeter(Meter m);

        ObservableCollection<Meter> GetMeters();

        void AddService(Service s);

        ObservableCollection<Service> GetServices();

        void InitDatabase();
    }
}
