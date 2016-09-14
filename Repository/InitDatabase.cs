using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repos;
using System.IO;
using System.Data.Entity;
using Entities;

namespace Repository
{
    public class InitDatabase
    {
        static DbContext context = new TarsashazDBEntities();
        AppartmentEFRepo appRepo;
        ServiceEFRepo servRepo;
        MainMeterEFRepo mMRepo;
        MeterEFRepo mRepo;
        ReadingEFRepo rRepo;
        InvoiceEFRepo invRepo;
        UserEFRepo userRepo;
        MessageEFRepo messageRepo;
        BuildingInvoiceEFRepo buildingRepo;
        private InitDatabase()
        {
            InitRepos();
            Empty();
            Console.WriteLine("all deleted");
            AddAll();
            Console.WriteLine("all added");
        }
        void AddAll()
        {
            AddServices();
            AddMainMeters();
            AddAppartments();
            AddMeters();
            AddReadings();
        }
        private void AddReadings()
        {
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 01), MeterId = mRepo.GetAll().ToList()[1].Id, Reading = 53 });
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 01), MeterId = mRepo.GetAll().ToList()[4].Id, Reading = 49 });
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 01), MeterId = mRepo.GetAll().ToList()[7].Id, Reading = 64 });
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 01), MeterId = mRepo.GetAll().ToList()[1].Id, Reading = 60 });
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 01), MeterId = mRepo.GetAll().ToList()[4].Id, Reading = 55 });
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 01), MeterId = mRepo.GetAll().ToList()[7].Id, Reading = 70 });
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 16), MeterId = mRepo.GetAll().ToList()[2].Id, Reading = 165 });
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 16), MeterId = mRepo.GetAll().ToList()[5].Id, Reading = 109 });
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 16), MeterId = mRepo.GetAll().ToList()[8].Id, Reading = 198 });
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 16), MeterId = mRepo.GetAll().ToList()[2].Id, Reading = 201 });
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 16), MeterId = mRepo.GetAll().ToList()[5].Id, Reading = 153 });
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 16), MeterId = mRepo.GetAll().ToList()[8].Id, Reading = 261 });
        }

        private void AddMeters()
        {
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[0].Id, ServiceId = (servRepo.GetAll()).ToList()[0].Id, Valid = false });
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[0].Id, ServiceId = (servRepo.GetAll()).ToList()[1].Id, Valid = true });
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[0].Id, ServiceId = (servRepo.GetAll()).ToList()[2].Id, Valid = true });
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[1].Id, ServiceId = (servRepo.GetAll()).ToList()[0].Id, Valid = false });
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[1].Id, ServiceId = (servRepo.GetAll()).ToList()[1].Id, Valid = true });
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[1].Id, ServiceId = (servRepo.GetAll()).ToList()[2].Id, Valid = false });
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[2].Id, ServiceId = (servRepo.GetAll()).ToList()[0].Id, Valid = false });
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[2].Id, ServiceId = (servRepo.GetAll()).ToList()[1].Id, Valid = false });
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[2].Id, ServiceId = (servRepo.GetAll()).ToList()[2].Id, Valid = false });
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[0].Id, ServiceId = (servRepo.GetAll()).ToList()[0].Id, Valid = false });
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[1].Id, ServiceId = (servRepo.GetAll()).ToList()[0].Id, Valid = false });
            mRepo.Insert(new Meters() { AppartmentId = (appRepo.GetAll()).ToList()[2].Id, ServiceId = (servRepo.GetAll()).ToList()[0].Id, Valid = false });
        }

        private void AddMainMeters()
        {
            mMRepo.Insert(new MainMeters { Date = new DateTime(2016, 07, 01), Reading = 172, ServiceId = (servRepo.GetAll()).ToList()[1].Id });
            mMRepo.Insert(new MainMeters { Date = new DateTime(2016, 08, 01), Reading = 435, ServiceId = (servRepo.GetAll()).ToList()[1].Id });
            mMRepo.Insert(new MainMeters { Date = new DateTime(2016, 07, 16), Reading = 532, ServiceId = (servRepo.GetAll()).ToList()[2].Id });
            mMRepo.Insert(new MainMeters { Date = new DateTime(2016, 08, 16), Reading = 1152, ServiceId = (servRepo.GetAll()).ToList()[2].Id });
            mMRepo.Insert(new MainMeters { Date = new DateTime(2016, 08, 31), ServiceId = (servRepo.GetAll()).ToList()[0].Id });
        }

        private void AddServices()
        {
            servRepo.Insert(new Services() { Name = "Közös költség", CalculateByResidents = true });
            servRepo.Insert(new Services() { Name = "Gáz", CalculateByResidents = false });
            servRepo.Insert(new Services() { Name = "Villany", CalculateByResidents = false });
        }
        private void AddAppartments()
        {
            appRepo.Insert(new Appartments() { Owner = "Béla", Size = 52, Residents = 2, Balance = 0 });
            appRepo.Insert(new Appartments() { Owner = "Gyula", Size = 68, Residents = 1, Balance = 0 });
            appRepo.Insert(new Appartments() { Owner = "Szilvia", Size = 73, Residents = 3, Balance = 0 });
        }
        private void InitRepos()
        {
            appRepo = new AppartmentEFRepo(context);
            servRepo = new ServiceEFRepo(context);
            mMRepo = new MainMeterEFRepo(context);
            mRepo = new MeterEFRepo(context);
            rRepo = new ReadingEFRepo(context);
            invRepo = new InvoiceEFRepo(context);
            userRepo = new UserEFRepo(context);
            messageRepo = new MessageEFRepo(context);
            buildingRepo = new BuildingInvoiceEFRepo(context);
        }
        private void Empty()
        {
            invRepo.DeleteAll();
            rRepo.DeleteAll();
            mRepo.DeleteAll();
            buildingRepo.DeleteAll();
            mMRepo.DeleteAll();
            servRepo.DeleteAll();
            userRepo.DeleteAll();
            messageRepo.DeleteAll();
            appRepo.DeleteAll();
        }
        static InitDatabase instance;
        public static InitDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    new InitDatabase();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }
    }
}
