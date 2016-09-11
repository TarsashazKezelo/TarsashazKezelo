using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;
using System.Data.Entity;

namespace Repository.Repos
{
    public class UserRepo : IUserRepo
    {

        int APPARTMENTID;

        static DbContext context = new TarsashazDBEntities();
        ReadingEFRepo readingRepo;
        AppartmentEFRepo appartmentRepo;
        InvoiceEFRepo invoiceRepo;
        MeterEFRepo meterRepo;
        UserEFRepo userRepo;
        MessageEFRepo messageRepo;
        public void InitRepos()
        {
            readingRepo = new ReadingEFRepo(context);
            appartmentRepo = new AppartmentEFRepo(context);
            invoiceRepo = new InvoiceEFRepo(context);
            meterRepo = new MeterEFRepo(context);
            userRepo = new UserEFRepo(context);
            messageRepo = new MessageEFRepo(context);
        }
        public UserRepo()
        {
            InitRepos();
        }
        public void AddReading(int meterId, double reading)
        {
            Readings read = new Readings();
            read.Date = DateTime.Today;
            read.MeterId = meterId;
            read.Reading = reading;
            readingRepo.Insert(read);
        }
        public Appartments GetAppartmentData()
        {
            return appartmentRepo.GetById(APPARTMENTID);
        }

        public IQueryable<Invoices> GetInvoices()
        {
            return invoiceRepo.GetInvoicesByAppartment(APPARTMENTID);
        }

        public IQueryable<Readings> GetReadingsByMeter(int meterId)
        {
            return readingRepo.GetReadingsByMeter(meterId);
        }

        public IQueryable<Meters> GetMeters()
        {
            return meterRepo.GetMetersByAppartment(APPARTMENTID);
        }

        public IQueryable<Invoices> GetInvoicesByMeter(int meterId)
        {
            return invoiceRepo.GetInvoicesByMeter(meterId);
        }

        public IQueryable<Invoices> GetActiveInvoices()
        {
            return invoiceRepo.Get(akt => !akt.Paid);
        }

        public IQueryable<Invoices> GetExpiredActiveInvoices()
        {
            return invoiceRepo.Get(akt => !akt.Paid && akt.Deadline < DateTime.Today);
        }

        public void ModifyPassword(int appartmentId, string oldPassword, string newPassword)
        {
            userRepo.ModifyPassword(userRepo.GetByAppartmentId(appartmentId).Id, oldPassword, newPassword);
        }

        public void AddMessage(string message)
        {
            Messages newMessage = new Messages();
            newMessage.AppartmentId = APPARTMENTID;
            newMessage.Message = message;
            newMessage.ToAdmin = true;
            messageRepo.Insert(newMessage);
        }

        public void DeleteMessage(int messageId)
        {
            messageRepo.Delete(messageId);
        }

        public IQueryable<Messages> GetMessages()
        {
            return messageRepo.GetMessagesByAppartment(APPARTMENTID);
        }

        public IQueryable<Messages> GetInbox()
        {
            return messageRepo.GetFromAdminByAppartment(APPARTMENTID);
        }

        public IQueryable<Messages> GetOutbox()
        {
            return messageRepo.GetToAdminByAppartment(APPARTMENTID);
        }

        public void PayToBalance(double amount)
        {
            appartmentRepo.GetById(APPARTMENTID).Balance += amount;
        }

        public void PayFromBalance(int invoiceId)
        {
            Invoices inv = invoiceRepo.GetById(invoiceId);
            appartmentRepo.GetById(APPARTMENTID).Balance -= inv.Amount;
            inv.Paid = true;
        }

        public void LogIn(int appartmentId, string password)
        {
            if (userRepo.Compare(userRepo.GetByAppartmentId(appartmentId).Id, password))
            {
                APPARTMENTID = appartmentId;
            }
        }
        public void LogOut()
        {
            APPARTMENTID = 0;
        }
    }
}
