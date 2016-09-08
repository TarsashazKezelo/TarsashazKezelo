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
    class UserRepo : IUserRepo
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
        public void LogIn(int id)
        {
            APPARTMENTID = userRepo.GetById(id).AppartmentId;
        }
        //for login: if Compare is true, LogIn
        public void AddReading(Readings reading)
        {
            readingRepo.Insert(reading);
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
            return readingRepo.GetReadingsByAppartment(APPARTMENTID).Where(akt => akt.MeterId == meterId);
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

        public void ModifyPassword(string oldPassword, string newPassword)
        {
            userRepo.Modify(APPARTMENTID, oldPassword, newPassword);
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
    }
}
