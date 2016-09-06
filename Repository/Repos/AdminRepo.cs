using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.IO;
using System.Data.Entity;
using System.Collections.ObjectModel;

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
        public void AddBuildingInvoice(BuildingInvoices buildingInvoice)
        {
            buildingRepo.Insert(buildingInvoice);
        }
        public void AddMainMeter(MainMeters mainMeter)
        {
            mainMeterRepo.Insert(mainMeter);
        }
        public void AddMeter(Meters meter)
        {
            meterRepo.Insert(meter);
        }
        public void AddService(Services service)
        {
            serviceRepo.Insert(service);
        }
        public ObservableCollection<Appartments> GetAppartments()
        {
            return new ObservableCollection<Appartments>(appartmentRepo.GetAll());
        }
        public ObservableCollection<BuildingInvoices> GetBuildingInvoices()
        {
            return new ObservableCollection<BuildingInvoices>(buildingRepo.GetAll());
        }
        public ObservableCollection<Invoices> GetInvoices()
        {
            return new ObservableCollection<Invoices>(invoiceRepo.GetAll());
        }
        public ObservableCollection<MainMeters> GetMainMeters()
        {
            return new ObservableCollection<MainMeters>(mainMeterRepo.GetAll());
        }
        public ObservableCollection<Meters> GetMeters()
        {
            return new ObservableCollection<Meters>(meterRepo.GetAll());
        }
        public ObservableCollection<Services> GetServices()
        {
            return new ObservableCollection<Services>(serviceRepo.GetAll());
        }
        public void ModifyAppartment(Appartments appartment)
        {
            appartmentRepo.Modify(appartment.Id, appartment.Owner, appartment.Residents.Value, appartment.Balance.Value);
        }
    }
}
