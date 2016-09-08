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
        private InitDatabase()
        {
            InitRepos();
            AddServices();
            AddMainMeters();
            AddAppartments();
            AddMeters();
            AddReadings();
        }
        private void AddReadings()
        {
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 01), MeterId =2, Reading =53});
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 01), MeterId =5, Reading =49});
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 01), MeterId =8, Reading =64});
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 01), MeterId =2, Reading =60});
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 01), MeterId =5, Reading =55});
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 01), MeterId =8, Reading =70});
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 16), MeterId =3, Reading =165});
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 16), MeterId =6, Reading =109});
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 07, 16), MeterId =9, Reading =198});
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 16), MeterId =3, Reading =201});
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 16), MeterId =6, Reading =153});
            rRepo.Insert(new Readings() { Date = new DateTime(2016, 08, 16), MeterId =9, Reading =261});
        }

        private void AddMeters()
        {
            mRepo.Insert(new Meters() { AppartmentId =1, ServiceId =1, Valid =false});
            mRepo.Insert(new Meters() { AppartmentId =1, ServiceId =2, Valid =true});
            mRepo.Insert(new Meters() { AppartmentId =1, ServiceId =3, Valid =true});
            mRepo.Insert(new Meters() { AppartmentId =2, ServiceId =1, Valid =false});
            mRepo.Insert(new Meters() { AppartmentId =2, ServiceId =2, Valid =true});
            mRepo.Insert(new Meters() { AppartmentId =2, ServiceId =3, Valid =false});
            mRepo.Insert(new Meters() { AppartmentId =3, ServiceId =1, Valid =false});
            mRepo.Insert(new Meters() { AppartmentId =3, ServiceId =2, Valid =false});
            mRepo.Insert(new Meters() { AppartmentId =3, ServiceId =3, Valid =false});
            mRepo.Insert(new Meters() { AppartmentId =1, ServiceId =1, Valid =false});
            mRepo.Insert(new Meters() { AppartmentId =2, ServiceId =1, Valid =false});
            mRepo.Insert(new Meters() { AppartmentId =3, ServiceId =1, Valid =false});
        }

        private void AddMainMeters()
        {
            mMRepo.Insert(new MainMeters { Date = new DateTime(2016, 07, 01), Reading = 172, ServiceId = 2 });
            mMRepo.Insert(new MainMeters { Date = new DateTime(2016, 08, 01), Reading = 435, ServiceId = 2 });
            mMRepo.Insert(new MainMeters { Date = new DateTime(2016, 07, 16), Reading = 532, ServiceId = 3 });
            mMRepo.Insert(new MainMeters { Date = new DateTime(2016, 08, 16), Reading = 1152, ServiceId = 3 });
            mMRepo.Insert(new MainMeters { Date = new DateTime(2016, 08, 31), ServiceId = 1 });
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
