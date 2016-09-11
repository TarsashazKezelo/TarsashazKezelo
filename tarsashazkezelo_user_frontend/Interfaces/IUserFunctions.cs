using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarsashazkezelo_user_frontend.Model;

namespace tarsashazkezelo_user_frontend.Interfaces
{
    interface IUserFunctions
    {
        void AddReading(int meterId, double reading);
        ObservableCollection<Meter> GetMeters();
        ObservableCollection<Reading> GetReadingsByMeter(int meterId);
        ObservableCollection<Invoice> GetInvoices();
        ObservableCollection<Invoice> GetInvoicesByMeter(int meterId);
        ObservableCollection<Invoice> GetActiveInvoices();
        ObservableCollection<Invoice> GetExpiredActiveInvoices();
        Appartment GetAppartmentData();
        void ModifyPassword(int appartmentId, string oldPassword, string newPassword);
        void AddMessage(string message);
        void DeleteMessage(int messageId);
        ObservableCollection<Message> GetMessages();
        ObservableCollection<Message> GetInbox();
        ObservableCollection<Message> GetOutbox();
        void PayToBalance(double amount);
        void PayFromBalance(int invoiceId);
        void LogIn(int appartmentId, string password);
        void LogOut();
    }
}
