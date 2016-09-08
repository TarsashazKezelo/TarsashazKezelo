using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Entities;

namespace Repository.Repos
{
    public interface IAdminRepo
    {
        BindingList<Appartments> GetAppartments();
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
        void InitDatabase();
        void AddMessage(string message, int appartmentId);
        void DeleteMessage(int messageId);
        IQueryable<Messages> GetMessages();
        IQueryable<Messages> GetInbox();
        IQueryable<Messages> GetOutbox();
    }
}
