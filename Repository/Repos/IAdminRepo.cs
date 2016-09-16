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
        ObservableCollection<BuildingInvoices> GetBuildingInvoicesByService(int serviceId);
        void AddBuildingInvoice(BuildingInvoices buildingInvoice);
        ObservableCollection<Invoices> GetInvoicesByAppartment(int appartmentId);
        ObservableCollection<MainMeters> GetMainMetersByService(int serviceId);
        void AddMainMeter(MainMeters mainMeter);
        ObservableCollection<Meters> GetMetersByAppartment(int appartmentId);
        void AddMeter(Meters meter);
        ObservableCollection<Services> GetServices();
        Services GetServiceById(int id);
        void AddService(Services service);
        void InitDatabase();
        void AddMessage(string message, int appartmentId);
        void DeleteMessage(int messageId);
        IQueryable<Messages> GetMessages();
        IQueryable<Messages> GetInbox();
        IQueryable<Messages> GetOutbox();
        void PaymentToBalance(int appartmentId, double amount);
        void PaymentFromBalance(int appartmentId, int invoiceId);
    }
}
