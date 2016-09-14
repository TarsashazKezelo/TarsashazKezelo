using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Repos
{
    public interface IUserRepo
    {
        void AddReading(int meterId, double reading);
        IQueryable<Meters> GetMeters();
        IQueryable<Readings> GetReadingsByMeter(int meterId);
        IQueryable<Invoices> GetInvoices();
        IQueryable<Invoices> GetInvoicesByMeter(int meterId);
        IQueryable<Invoices> GetActiveInvoices();
        IQueryable<Invoices> GetExpiredActiveInvoices();
        Appartments GetAppartmentData();
        void ModifyPassword(int appartmentId, string oldPassword, string newPassword);
        void AddMessage(string message);
        void DeleteMessage(int messageId);
        IQueryable<Messages> GetMessages();
        IQueryable<Messages> GetInbox();
        IQueryable<Messages> GetOutbox();
        void LogIn(int appartmentId, string password);
        void LogOut();
    }
}
