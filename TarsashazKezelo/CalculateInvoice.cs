using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository.Repos;
using System.Data.Entity;
using System.IO;

namespace TarsashazKezelo
{
    class CalculateInvoice
    {
        static string loc = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Entities\\TarsashazDB.mdf");
        static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=" + loc + ";Integrated Security=True";
        static DbContext context = new DbContext(connString);
        static AppartmentEFRepo AppRepo;
        static BuildingInvoiceEFRepo BInvRepo;
        static InvoiceEFRepo InvRepo;
        static MainMeterEFRepo MMRepo;
        static MeterEFRepo MeterRepo;
        static ReadingEFRepo ReadingRepo;
        static ServiceEFRepo ServRepo;
        static void InitRepos()
        {
            AppRepo = new AppartmentEFRepo(context);
            BInvRepo = new BuildingInvoiceEFRepo(context);
            InvRepo = new InvoiceEFRepo(context);
            MMRepo = new MainMeterEFRepo(context);
            MeterRepo = new MeterEFRepo(context);
            ReadingRepo = new ReadingEFRepo(context);
            ServRepo = new ServiceEFRepo(context);
        }
        public void Calculate()
        {
            if (BInvRepo.GetLast().MainMeters.Date > InvRepo.GetLast().Readings.Date)
            {
                Calculate(BInvRepo.GetLast());
            }
        }
        public void Calculate(BuildingInvoices bInv)
        {
            MainMeters main = bInv.MainMeters;
            MainMeters prev = MMRepo.Get(akt => akt.Id < main.Id).OrderBy(x => x.Id).Last();
            int servId = main.ServiceId;
            List<Meters> validMeters = MeterRepo.Get(akt => akt.ServiceId == servId && akt.Valid).ToList();
            List<Meters> withoutMeters = MeterRepo.Get(akt => akt.ServiceId == servId && !akt.Valid).ToList();
            double amount = bInv.Amount;
            if (main.Reading != null)
            {
                double unit = (bInv.Amount / (main.Reading - prev.Reading)).Value;
                foreach (var item in validMeters)
                {
                    Readings lastR = ReadingRepo.Get(akt => akt.MeterId == item.Id).OrderBy(akt => akt.Id).Last();
                    Readings prevR = ReadingRepo.Get(akt => akt.MeterId == item.Id && akt.Id < lastR.Id).OrderBy(akt => akt.Id).Last();
                    Invoices inv = new Invoices();
                    inv.ReadingId = lastR.Id;
                    inv.Amount = ((lastR.Reading - prevR.Reading) * unit).Value;
                    amount -= inv.Amount;
                    inv.Deadline = DateTime.Today.AddDays(14);
                    InvRepo.Insert(inv);
                }
            }
            CalculateBySize(withoutMeters, amount);
        }
        public void CalculateBySize(List<Meters> meters, double amount)
        {
            double allsize = 0;
            foreach (var item in meters)
            {
                allsize += item.Appartments.Size.Value;
            }
            foreach (var item in meters)
            {
                Invoices inv = new Invoices();
                inv.Amount = (item.Appartments.Size * amount / allsize).Value;
                inv.Deadline = DateTime.Today.AddDays(14);
                InvRepo.Insert(inv);
            }

        }
        public void CalculateByResidents(List<Meters> meters, double amount)
        {
            int allresidents = 0;
            foreach (var item in meters)
            {
                allresidents += item.Appartments.Residents.Value;
            }
            foreach (var item in meters)
            {
                Invoices inv = new Invoices();
                inv.Amount = (item.Appartments.Residents * amount / allresidents).Value;
                inv.Deadline = DateTime.Today.AddDays(14);
                InvRepo.Insert(inv);
            }
        }
    }
}
