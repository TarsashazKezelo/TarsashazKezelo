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
    class ComplexRepositoryMethods : IComplexRepositoryMethods
    {
        static DbContext context;
        BuildingInvoiceEFRepo bInvRepo;
        MeterEFRepo meterRepo;
        MainMeterEFRepo mainRepo;
        InvoiceEFRepo invRepo;
        ServiceEFRepo servRepo;
        ReadingEFRepo readingRepo;
        public ComplexRepositoryMethods(DbContext ctx)
        {
            context = ctx;
        }

        private void InitRepos()
        {
            bInvRepo = new BuildingInvoiceEFRepo(context);
            meterRepo = new MeterEFRepo(context);
            mainRepo = new MainMeterEFRepo(context);
            invRepo = new InvoiceEFRepo(context);
            servRepo = new ServiceEFRepo(context);
            readingRepo = new ReadingEFRepo(context);
        }
        public void Calculate(BuildingInvoices buildingInvoice)
        {
            InitRepos();
            MainMeters main = mainRepo.GetById(buildingInvoice.MainMeterId);
            Services serv = servRepo.GetById(main.ServiceId);
            double amount = buildingInvoice.Amount;
            string desc = buildingInvoice.Description;
            if (main.Reading != null)
            {
                CalculateByMeters(ref amount, main, desc);
            }
            if (serv.CalculateByResidents)
            {
                CalculateByResidents(amount, main, desc);
            }
            else
            {
                CalculateBySize(amount, main, desc);
            }
        }
        private void CalculateByMeters(ref double amount, MainMeters main, string description)
        {
            List<Meters> meters = new List<Meters>(meterRepo.GetValidByService(main.ServiceId));
            foreach (var item in meters)
            {
                double unit = amount / mainRepo.GetReadingDifference(main.Id);
                Invoices inv = new Invoices();
                inv.Deadline = DateTime.Today.AddDays(14);
                try
                {
                    inv.ReadingId = readingRepo.Get(akt => akt.MeterId == item.Id && akt.Date == main.Date).SingleOrDefault().Id;
                }
                catch (Exception)
                {
                    readingRepo.LateInsert(main.Date, item.Id);
                    inv.ReadingId = readingRepo.Get(akt => akt.MeterId == item.Id && akt.Date == main.Date).SingleOrDefault().Id;
                }
                inv.Amount = unit * readingRepo.GetReadingDifference(inv.ReadingId);
                inv.Description = description;
                inv.Paid = false;
                invRepo.Insert(inv);
            }
        }
        private void CalculateBySize(double amount, MainMeters main, string description)
        {
            List<Meters> meters = new List<Meters>(meterRepo.GetInvalidByService(main.ServiceId));
            if (amount != 0 && meters.Count() == 0)
            {
                meters = new List<Meters>(meterRepo.GetMetersByService(main.ServiceId));
            }
            double allsize = 0;
            foreach (var item in meters)
            {
                allsize += item.Appartments.Size.Value;
            }
            foreach (var item in meters.ToList())
            {
                Invoices inv = new Invoices();
                inv.Amount = (item.Appartments.Size * amount / allsize).Value;
                inv.Deadline = DateTime.Today.AddDays(14);
                inv.Description = description;
                inv.Paid = false;
                try
                {
                    inv.ReadingId = readingRepo.GetReadingsByMeter(item.Id).Where(akt => akt.Date == main.Date).SingleOrDefault().Id;
                }
                catch (Exception)
                {
                    readingRepo.LateInsert(main.Date, item.Id);
                    inv.ReadingId = readingRepo.GetReadingsByMeter(item.Id).Where(akt => akt.Date == main.Date).SingleOrDefault().Id;
                }
                invRepo.Insert(inv);
            }
        }
        private void CalculateByResidents(double amount, MainMeters main, string description)
        {
            List<Meters> meters = new List<Meters>(meterRepo.GetInvalidByService(main.ServiceId));
            if (amount != 0 && meters.Count() == 0)
            {
                meters = new List<Meters>(meterRepo.GetMetersByService(main.ServiceId));
            }
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
                inv.Description = description;
                inv.Paid = false;
                try
                {
                    inv.ReadingId = readingRepo.GetReadingsByMeter(item.Id).Where(akt => akt.Date == main.Date).SingleOrDefault().Id;
                }
                catch (Exception)
                {
                    readingRepo.LateInsert(main.Date, item.Id);
                    inv.ReadingId = readingRepo.GetReadingsByMeter(item.Id).Where(akt => akt.Date == main.Date).SingleOrDefault().Id;
                }
                invRepo.Insert(inv);
            }
        }
    }
}
