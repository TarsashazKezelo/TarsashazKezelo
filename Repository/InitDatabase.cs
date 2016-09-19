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
            rRepo.Insert(new Readings() { MeterId = mRepo.GetAll().ToList()[0].Id, Reading = 40 });
            rRepo.Insert(new Readings() { MeterId = mRepo.GetAll().ToList()[1].Id, Reading = 30 });
            rRepo.Insert(new Readings() { MeterId = mRepo.GetAll().ToList()[2].Id, Reading = 30 });
            rRepo.Insert(new Readings() { MeterId = mRepo.GetAll().ToList()[3].Id, Reading = 50 });
            rRepo.Insert(new Readings() { MeterId = mRepo.GetAll().ToList()[4].Id, Reading = 60 });
            rRepo.Insert(new Readings() { MeterId = mRepo.GetAll().ToList()[5].Id, Reading = 40 });
            rRepo.Insert(new Readings() { MeterId = mRepo.GetAll().ToList()[6].Id});
            rRepo.Insert(new Readings() { MeterId = mRepo.GetAll().ToList()[7].Id});
            rRepo.Insert(new Readings() { MeterId = mRepo.GetAll().ToList()[8].Id});
        }

        private void AddMeters()
        {
            mRepo.Insert(new Meters() { AppartmentId = appRepo.GetAll().ToList()[0].Id, ServiceId = servRepo.GetAll().ToList()[0].Id, Valid = true });
            mRepo.Insert(new Meters() { AppartmentId = appRepo.GetAll().ToList()[1].Id, ServiceId = servRepo.GetAll().ToList()[0].Id, Valid = true });
            mRepo.Insert(new Meters() { AppartmentId = appRepo.GetAll().ToList()[2].Id, ServiceId = servRepo.GetAll().ToList()[0].Id, Valid = true });
            mRepo.Insert(new Meters() { AppartmentId = appRepo.GetAll().ToList()[0].Id, ServiceId = servRepo.GetAll().ToList()[1].Id, Valid = true });
            mRepo.Insert(new Meters() { AppartmentId = appRepo.GetAll().ToList()[1].Id, ServiceId = servRepo.GetAll().ToList()[1].Id, Valid = true });
            mRepo.Insert(new Meters() { AppartmentId = appRepo.GetAll().ToList()[2].Id, ServiceId = servRepo.GetAll().ToList()[1].Id, Valid = true });
            mRepo.Insert(new Meters() { AppartmentId = appRepo.GetAll().ToList()[0].Id, ServiceId = servRepo.GetAll().ToList()[2].Id, Valid = false });
            mRepo.Insert(new Meters() { AppartmentId = appRepo.GetAll().ToList()[1].Id, ServiceId = servRepo.GetAll().ToList()[2].Id, Valid = false });
            mRepo.Insert(new Meters() { AppartmentId = appRepo.GetAll().ToList()[2].Id, ServiceId = servRepo.GetAll().ToList()[2].Id, Valid = false });
            
        }

        private void AddMainMeters()
        {
            mMRepo.Insert(new MainMeters() { Reading = 100, ServiceId = (servRepo.GetAll()).ToList()[0].Id });
            mMRepo.Insert(new MainMeters() { Reading = 150, ServiceId = (servRepo.GetAll()).ToList()[1].Id });
            mMRepo.Insert(new MainMeters() { ServiceId = (servRepo.GetAll()).ToList()[2].Id });
        }

        private void AddServices()
        {
            servRepo.Insert(new Services() { Name = "Gáz", CalculateByResidents = false });
            servRepo.Insert(new Services() { Name = "Villany", CalculateByResidents = false });
            servRepo.Insert(new Services() { Name = "Közös költség", CalculateByResidents = true });
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
