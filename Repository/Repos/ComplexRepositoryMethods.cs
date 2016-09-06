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
        static string loc = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Entities\\TarsashazDB.mdf");
        static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=" + loc + ";Integrated Security=True";
        static DbContext context = new DbContext(connString);
        public void Calculate(BuildingInvoices buildingInvoice)
        {
            BuildingInvoiceEFRepo bInvRepo = new BuildingInvoiceEFRepo(context);
            MainMeters main = buildingInvoice.MainMeters;
            MainMeters prev = bInvRepo.GetLast().MainMeters;
            MeterEFRepo meterRepo = new MeterEFRepo(context);
            double amount = buildingInvoice.Amount;
            if (main.Reading!=null)
            {
                CalculateByMeters(meterRepo.GetValid(), ref amount);
            }
            Services serv = main.Services;
            if (serv.CalculateByResidents)
            {
                CalculateByResidents(meterRepo.GetInvalid(), amount);
            }
            else
            {
                CalculateBySize(meterRepo.GetInvalid(), amount);
            }
        }
        private void CalculateByMeters(IQueryable<Meters> meters, ref double amount)
        {

        }
        private void CalculateBySize(IQueryable<Meters> meters,double amount)
        {

        }
        private void CalculateByResidents(IQueryable<Meters> meters,double amount)
        {

        }
    }
}
