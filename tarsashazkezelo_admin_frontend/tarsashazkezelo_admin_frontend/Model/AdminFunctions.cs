using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository.Repos;
using tarsashazkezelo_admin_frontend.Converters;
using tarsashazkezelo_admin_frontend.Interfaces;

namespace tarsashazkezelo_admin_frontend.Model
{
    public class AdminFunctions : IAdminFunctions
    {
        IAdminRepo _adminRepo = new AdminRepo();

        public BindingList<Apartment> GetApartments()
        {
            BindingList<Appartments> list = _adminRepo.GetAppartments();
            BindingList<Apartment> convertedList = new BindingList<Apartment>();

            foreach (Appartments a in list)
            {
                convertedList.Add(RepoConverter.ConvertAppartmentsToApartment(a));
            }

            return convertedList;

        }

        public void ModifyApartment(Apartment a)
        {
            _adminRepo.ModifyAppartment(RepoConverter.ConvertApartmentToAppartments(a));
        }

        public void AddBuildingInvoice(BuildingInvoice bi)
        {
            _adminRepo.AddBuildingInvoice(RepoConverter.ConvertBuildingInvoiceToBuildingInvoices(bi));
        }

        public ObservableCollection<BuildingInvoice> GetBuildingInvoicesByService(Service s)
        {
            ObservableCollection<BuildingInvoices> collection = _adminRepo.GetBuildingInvoicesByService(s.ID);
            ObservableCollection<BuildingInvoice> convertedCollection=new ObservableCollection<BuildingInvoice>();

            foreach (BuildingInvoices bi in collection)
            {
                convertedCollection.Add(RepoConverter.ConvertBuildingInvoicesToBuildingInvoice(bi));
            }
            return convertedCollection;
        }

        public ObservableCollection<Invoice> GetInvoicesByApartment(Apartment a)
        {
            ObservableCollection<Invoices> collection = _adminRepo.GetInvoicesByAppartment(a.ID);
            ObservableCollection<Invoice> convertedCollection = new ObservableCollection<Invoice>();

            foreach (Invoices i in collection)
            {
                convertedCollection.Add(RepoConverter.ConvertInvoicesToInvoice(i));
            }
            return convertedCollection;
        }

        public void AddMainMeter(MainMeter mm)
        {
            _adminRepo.AddMainMeter(RepoConverter.ConvertMainMeterToMainMeters(mm));
        }

        public ObservableCollection<MainMeter> GetMainMetersByService(Service s)
        {
            ObservableCollection<MainMeters> collection = _adminRepo.GetMainMetersByService(s.ID);
            ObservableCollection<MainMeter> convertedCollection = new ObservableCollection<MainMeter>();

            foreach (MainMeters i in collection)
            {
                convertedCollection.Add(RepoConverter.ConvertMainMetersToMainMeter(i));
            }
            return convertedCollection;
        }

        public void AddMeter(Meter m)
        {
            _adminRepo.AddMeter(RepoConverter.ConvertMeterToMeters(m));
        }

        public ObservableCollection<Meter> GetMetersByApartment(Apartment a)
        {
            ObservableCollection<Meters> collection = _adminRepo.GetMetersByAppartment(a.ID);
            ObservableCollection<Meter> convertedCollection = new ObservableCollection<Meter>();

            foreach (Meters m in collection)
            {
                convertedCollection.Add(RepoConverter.ConvertMetersToMeter(m));
            }
            return convertedCollection;
        }

        public void AddService(Service s)
        {
            _adminRepo.AddService(RepoConverter.ConvertServiceToServices(s));
        }

        public ObservableCollection<Service> GetServices()
        {
            ObservableCollection<Services> collection = _adminRepo.GetServices();
            ObservableCollection<Service> convertedCollection = new ObservableCollection<Service>();

            foreach (Services s in collection)
            {
                convertedCollection.Add(RepoConverter.ConvertServicesToService(s));
            }
            return convertedCollection;
        }

        public Service GetServiceById(int id)
        {
            return RepoConverter.ConvertServicesToService(_adminRepo.GetServiceById(id));
        }

        public void InitDatabase()
        {
            _adminRepo.InitDatabase();
        }
    }
}
