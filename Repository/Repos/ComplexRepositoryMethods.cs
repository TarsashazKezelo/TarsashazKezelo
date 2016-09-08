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
        static DbContext context = new TarsashazDBEntities();
        BuildingInvoiceEFRepo bInvRepo;
        MeterEFRepo meterRepo;
        MainMeterEFRepo mainRepo;
        InvoiceEFRepo invRepo;
        private void InitRepos()
        {
            bInvRepo = new BuildingInvoiceEFRepo(context);
            meterRepo = new MeterEFRepo(context);
            mainRepo = new MainMeterEFRepo(context);
            invRepo = new InvoiceEFRepo(context);
        }
        public void Calculate(BuildingInvoices buildingInvoice)
        {
            InitRepos();
            MainMeters main = buildingInvoice.MainMeters;
            Services serv = main.Services;
            double amount = buildingInvoice.Amount;
            string desc = buildingInvoice.Description;
            if (main.Reading != null)
            {
                CalculateByMeters(meterRepo, mainRepo, invRepo, ref amount, serv.Id, desc);
            }
            if (serv.CalculateByResidents)
            {
                CalculateByResidents(meterRepo, amount, serv.Id, desc);
            }
            else
            {
                CalculateBySize(meterRepo, amount, serv.Id, desc);
            }
        }
        private void CalculateByMeters(MeterEFRepo repo, MainMeterEFRepo mainRepo, InvoiceEFRepo invRepo, ref double amount, int serviceId, string description)
        {
            IQueryable<Meters> meters = repo.GetValidByService(serviceId);
            foreach (var item in meters)
            {
                double unit = amount / mainRepo.GetLastReadingDifference(serviceId);
                Invoices inv = new Invoices();
                inv.Deadline = DateTime.Today.AddDays(14);
                inv.Amount = repo.GetLastReadingDifference(item.Id) * unit;
                inv.ReadingId = repo.GetLastReadingId(item.Id);
                inv.Description = description;
                inv.Paid = false;
                invRepo.Insert(inv);
            }
        }
        private void CalculateBySize(MeterEFRepo repo, double amount, int serviceId, string description)
        {
            IQueryable<Meters> meters = meterRepo.GetInvalidByService(serviceId);
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
                inv.Description = description;
                inv.Paid = false;
                invRepo.Insert(inv);
            }
        }
        private void CalculateByResidents(MeterEFRepo repo, double amount, int serviceId, string description)
        {
            IQueryable<Meters> meters = meterRepo.GetInvalidByService(serviceId);
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
                invRepo.Insert(inv);
            }
        }
    }
}
