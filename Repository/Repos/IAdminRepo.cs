using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Collections.ObjectModel;

namespace Repository.Repos
{
    interface IAdminRepo
    {
        ObservableCollection<Appartments> GetAppartments();
        void ModifyAppartment(Appartments appartment);
        ObservableCollection<BuildingInvoices> GetBuildingInvoices();
        void AddBuildingInvoice(BuildingInvoices buildingInvoice);
        ObservableCollection<Invoices> GetInvoices();
        ObservableCollection<MainMeters> GetMainMeters();
        void AddMainMeter(MainMeters mainMeter);
        ObservableCollection<Meters> GetMeters();
        void AddMeter(Meters meter);
        ObservableCollection<Services> GetServices();
        void AddService(Services service);
    }
}
