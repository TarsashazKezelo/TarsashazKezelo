using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.Converters
{
    public static class RepoConverter
    {
        public static Apartment ConvertAppartmentsToApartment(Appartments a)
        {
            return new Apartment() { Balance = a.Balance, ID = a.Id, Owner = a.Owner, Residents = a.Residents, Size = a.Size };
        }

        public static Appartments ConvertApartmentToAppartments(Apartment a)
        {
            return new Appartments() { Balance = a.Balance, Id = a.ID, Owner = a.Owner, Residents = a.Residents, Size = a.Size };
        }

        public static BuildingInvoice ConvertBuildingInvoicesToBuildingInvoice(BuildingInvoices bi)
        {
            return new BuildingInvoice() { Amount = bi.Amount, Date = bi.Date, Description = bi.Description, ID = bi.Id, MainMeterID = bi.MainMeterId };
        }

        public static BuildingInvoices ConvertBuildingInvoiceToBuildingInvoices(BuildingInvoice bi)
        {
            return new BuildingInvoices() { Amount = bi.Amount, Date = bi.Date, Description = bi.Description, Id = bi.ID, MainMeterId = bi.MainMeterID };
        }

        public static Invoice ConvertInvoicesToInvoice(Invoices i)
        {
            return new Invoice() { Amount = i.Amount, DeadLine = i.Deadline, Description = i.Description, ID = i.Id, ReadingID = i.ReadingId };
        }

        public static MainMeter ConvertMainMetersToMainMeter(MainMeters mm)
        {
            return new MainMeter() { Date = mm.Date, ID = mm.Id, Reading = mm.Reading, ServiceID = mm.ServiceId };
        }

        public static MainMeters ConvertMainMeterToMainMeters(MainMeter mm)
        {
            return new MainMeters() { Date = mm.Date, Id = mm.ID, Reading = mm.Reading, ServiceId = mm.ServiceID };
        }

        public static Meter ConvertMetersToMeter(Meters m)
        {
            return new Meter() { ID = m.Id, ServiceID = m.ServiceId, AppartmentID = m.AppartmentId, Valid = m.Valid };
        }

        public static Meters ConvertMeterToMeters(Meter m)
        {
            return new Meters() { Id = m.ID, ServiceId = m.ServiceID, AppartmentId = m.AppartmentID, Valid = m.Valid };
        }

        public static Service ConvertServicesToService(Services s)
        {
            return new Service() { ID = s.Id,Name = s.Name, CalculateByResidents = s.CalculateByResidents};
        }

        public static Services ConvertServiceToServices(Service s)
        {
            return new Services() { Id = s.ID, Name = s.Name, CalculateByResidents = s.CalculateByResidents };
        }
    }
}
