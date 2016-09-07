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

        static string loc = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Entities\\TarsashazDB.mdf");
        static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=" + loc + ";Integrated Security=True";
        static DbContext context = new DbContext(connString);
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
            throw new NotImplementedException();
        }

        public IQueryable<Invoices> GetExpiredActiveInvoices()
        {
            throw new NotImplementedException();
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
            appartmentRepo.GetById(APPARTMENTID).Balance -=inv.Amount;
            inv.Paid = true;
        }
    }
}
