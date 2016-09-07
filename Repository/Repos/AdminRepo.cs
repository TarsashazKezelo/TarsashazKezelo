using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using System.Collections.ObjectModel;
using Entities;
using System.Reflection;

namespace Repository.Repos
{
    class AdminRepo : IAdminRepo
    {
        static string loc = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Entities\\TarsashazDB.mdf");
        static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=" + loc + ";Integrated Security=True";
        static DbContext context = new DbContext(connString);
        BuildingInvoiceEFRepo buildingRepo;
        MainMeterEFRepo mainMeterRepo;
        MeterEFRepo meterRepo;
        ServiceEFRepo serviceRepo;
        AppartmentEFRepo appartmentRepo;
        InvoiceEFRepo invoiceRepo;
        public AdminRepo()
        {
            InitRepos();
            Reflection();
        }
        void InitRepos()
        {
            buildingRepo = new BuildingInvoiceEFRepo(context);
            mainMeterRepo = new MainMeterEFRepo(context);
            meterRepo = new MeterEFRepo(context);
            serviceRepo = new ServiceEFRepo(context);
            appartmentRepo = new AppartmentEFRepo(context);
            invoiceRepo = new InvoiceEFRepo(context);
        }
        Type BuildingInvoice;
        Type MainMeter;
        Type Meter;
        Type Service;
        Type Apartment;
        Type Invoice;
        object bI;
        object mM;
        object m;
        object s;
        object a;
        object i;
        void Reflection()
        {
            string location = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName) +
                @"\tarsashazkezelo_admin_frontend\tarsashazkezelo_admin_frontend\bin\Debug\valami.dll";
            Assembly refLib = Assembly.LoadFile(location);
            BuildingInvoice = refLib.GetType("tarsashazkezelo_admin_frontend.Model.BuildingInvoice");
            MainMeter = refLib.GetType("tarsashazkezelo_admin_frontend.Model.MainMeter");
            Meter = refLib.GetType("tarsashazkezelo_admin_frontend.Model.Meter");
            Service = refLib.GetType("tarsashazkezelo_admin_frontend.Model.Service");
            Apartment = refLib.GetType("tarsashazkezelo_admin_frontend.Model.Apartment");
            Invoice = refLib.GetType("tarsashazkezelo_admin_frontend.Model.Invoice");
            bI = Activator.CreateInstance(BuildingInvoice);
            mM = Activator.CreateInstance(MainMeter);
            m = Activator.CreateInstance(Meter);
            s = Activator.CreateInstance(Service);
            a = Activator.CreateInstance(Apartment);
            i = Activator.CreateInstance(Invoice);
        }
        public void AddBuildingInvoice(BuildingInvoice buildingInvoice)
        {
            BuildingInvoices bInv = new BuildingInvoices();
            bInv.Amount = buildingInvoice.Amount;
            bInv.Date = buildingInvoice.Date;
            bInv.Description = buildingInvoice.Description;
            bInv.Id = buildingInvoice.ID;
            bInv.MainMeterId = buildingInvoice.MainMeterId;
            buildingRepo.Insert(bInv);
        }
        public void AddMainMeter(MainMeter mainMeter)
        {
            MainMeters mMeter = new MainMeters();
            mMeter.Date = mainMeter.Date;
            mMeter.Id = mainMeter.ID;
            mMeter.Reading = mainMeter.Reading;
            mMeter.ServiceId = mainMeter.ServiceId;
            mainMeterRepo.Insert(mMeter);
        }
        public void AddMeter(Meter meter)
        {
            Meters m = new Meters();
            m.AppartmentId = meter.AppartmentId;
            m.Id = meter.ID;
            m.ServiceId = meter.ServiceId;
            m.Valid = meter.Valid;
            meterRepo.Insert(m);
        }
        public void AddService(Service service)
        {
            Services serv = new Services();
            serv.CalculateByResidents = service.CalculateByResidents;
            serv.Id = service.ID;
            serv.Name = service.Name;
            serviceRepo.Insert(serv);
        }
        public ObservableCollection<Apartment> GetAppartments()
        {
            ObservableCollection<Apartment> oc = new ObservableCollection<Apartment>();
            foreach (var item in appartmentRepo.GetAll())
            {
                Apartment app = new Apartment();
                app.Balance = item.Balance.Value;
                app.ID = item.Id;
                app.Owner = item.Owner;
                app.Residents = item.Residents.Value;
                oc.Add(app);
            }
            return oc;
        }
        public ObservableCollection<BuildingInvoice> GetBuildingInvoices()
        {
            ObservableCollection<BuildingInvoice> oc = new ObservableCollection<BuildingInvoice>();
            foreach (var item in buildingRepo.GetAll())
            {
                BuildingInvoice bInv = new BuildingInvoice();
                bInv.Amount = item.Amount;
                bInv.Date = item.Date;
                bInv.Description = item.Description;
                bInv.ID = item.Id;
                bInv.MainMeterId = item.MainMeterId;
                oc.Add(bInv);
            }
            return oc;
        }
        public ObservableCollection<Invoice> GetInvoices()
        {
            ObservableCollection<Invoice> oc = new ObservableCollection<Invoice>();
            foreach (var item in invoiceRepo.GetAll())
            {
                Invoice inv = new Invoice();
                inv.Amount = item.Amount;
                inv.DeadLine = item.Deadline;
                inv.Description = item.Description;
                inv.ID = item.Id;
                inv.ReadingId = item.ReadingId;
                oc.Add(inv);
            }
            return oc;
        }
        public ObservableCollection<MainMeter> GetMainMeters()
        {
            ObservableCollection<MainMeter> oc = new ObservableCollection<MainMeter>();
            foreach (var item in mainMeterRepo.GetAll())
            {
                MainMeter mMeter = new MainMeter();
                mMeter.Date = item.Date;
                mMeter.ID = item.Id;
                mMeter.Reading = item.Reading;
                mMeter.ServiceId = item.ServiceId;
                oc.Add(mMeter);
            }
            return oc;
        }
        public ObservableCollection<Meter> GetMeters()
        {
            ObservableCollection<Meter> oc = new ObservableCollection<Meter>();
            foreach (var item in meterRepo.GetAll())
            {
                Meter meter = new Meter();
                meter.AppartmentId = item.AppartmentId;
                meter.ID = item.Id;
                meter.Valid = item.Valid;
                meter.ServiceId = item.ServiceId;
                oc.Add(meter);
            }
            return oc;
        }
        public ObservableCollection<Service> GetServices()
        {
            ObservableCollection<Service> oc = new ObservableCollection<Service>();
            foreach (var item in serviceRepo.GetAll())
            {
                Service serv = new Service();
                serv.CalculateByResidents = item.CalculateByResidents;
                serv.ID = item.Id;
                serv.Name = item.Name;
                oc.Add(serv);
            }
            return oc;
        }
        public void ModifyAppartment(Apartment appartment)
        {
            appartmentRepo.Modify(appartment.ID, appartment.Owner, appartment.Residents, appartment.Balance);
        }
    }
}
