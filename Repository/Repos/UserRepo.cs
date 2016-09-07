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
        public void InitRepos()
        {
            readingRepo = new ReadingEFRepo(context);
            appartmentRepo = new AppartmentEFRepo(context);
            invoiceRepo = new InvoiceEFRepo(context);
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

        public IQueryable<Readings> GetReadings()
        {
            return readingRepo.GetReadingsByAppartment(APPARTMENTID);
        }
    }
}
