using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarsashazkezelo_user_frontend.Interfaces;
using Repository.Repos;
using tarsashazkezelo_user_frontend.Converters;

namespace tarsashazkezelo_user_frontend.Model
{
    public class UserFunctions : IUserFunctions
    {
        IUserRepo repo = new UserRepo();
        public void AddMessage(string message)
        {
            repo.AddMessage(message);
        }

        public void AddReading(int meterId, double reading)
        {
            repo.AddReading(meterId, reading);
        }

        public void DeleteMessage(int messageId)
        {
            repo.DeleteMessage(messageId);
        }

        public ObservableCollection<Invoice> GetActiveInvoices()
        {
            ObservableCollection<Invoice> oc = new ObservableCollection<Invoice>();
            foreach (var item in repo.GetActiveInvoices())
            {
                oc.Add(RepoConverter.ConvertInvoicesToInvoice(item));
            }
            return oc;
        }

        public Appartment GetAppartmentData()
        {
            return RepoConverter.ConvertAppartmentsToAppartment(repo.GetAppartmentData());
        }

        public ObservableCollection<Invoice> GetExpiredActiveInvoices()
        {
            ObservableCollection<Invoice> oc = new ObservableCollection<Invoice>();
            foreach (var item in repo.GetExpiredActiveInvoices())
            {
                oc.Add(RepoConverter.ConvertInvoicesToInvoice(item));
            }
            return oc;
        }

        public ObservableCollection<Message> GetInbox()
        {
            ObservableCollection<Message> oc = new ObservableCollection<Message>();
            foreach (var item in repo.GetInbox())
            {
                oc.Add(RepoConverter.ConvertMessagesToMessage(item));
            }
            return oc;
        }

        public ObservableCollection<Invoice> GetInvoices()
        {
            ObservableCollection<Invoice> oc = new ObservableCollection<Invoice>();
            foreach (var item in repo.GetInvoices())
            {
                oc.Add(RepoConverter.ConvertInvoicesToInvoice(item));
            }
            return oc;
        }

        public ObservableCollection<Invoice> GetInvoicesByMeter(int meterId)
        {
            ObservableCollection<Invoice> oc = new ObservableCollection<Invoice>();
            foreach (var item in repo.GetInvoicesByMeter(meterId))
            {
                oc.Add(RepoConverter.ConvertInvoicesToInvoice(item));
            }
            return oc;
        }

        public ObservableCollection<Message> GetMessages()
        {
            ObservableCollection<Message> oc = new ObservableCollection<Message>();
            foreach (var item in repo.GetMessages())
            {
                oc.Add(RepoConverter.ConvertMessagesToMessage(item));
            }
            return oc;
        }

        public ObservableCollection<Meter> GetMeters()
        {
            ObservableCollection<Meter> oc = new ObservableCollection<Meter>();
            foreach (var item in repo.GetMeters())
            {
                oc.Add(RepoConverter.ConvertMetersToMeter(item));
            }
            return oc;
        }

        public ObservableCollection<Message> GetOutbox()
        {
            ObservableCollection<Message> oc = new ObservableCollection<Message>();
            foreach (var item in repo.GetOutbox())
            {
                oc.Add(RepoConverter.ConvertMessagesToMessage(item));
            }
            return oc;
        }

        public ObservableCollection<Reading> GetReadingsByMeter(int meterId)
        {
            ObservableCollection<Reading> oc = new ObservableCollection<Reading>();
            foreach (var item in repo.GetReadingsByMeter(meterId))
            {
                oc.Add(RepoConverter.ConvertReadingsToReading(item));
            }
            return oc;
        }

        public void LogIn(int appartmentId, string password)
        {
            repo.LogIn(appartmentId, password);
        }

        public void LogOut()
        {
            repo.LogOut();
        }

        public void ModifyPassword(int appartmentId, string oldPassword, string newPassword)
        {
            repo.ModifyPassword(appartmentId, oldPassword, newPassword);
        }

        public void PayFromBalance(int invoiceId)
        {
            repo.PayFromBalance(invoiceId);
        }

        public void PayToBalance(double amount)
        {
            repo.PayToBalance(amount);
        }
    }
}
