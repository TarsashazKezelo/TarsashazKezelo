using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarsashazkezelo_user_frontend.Model;

namespace tarsashazkezelo_user_frontend.Converters
{
    public static class RepoConverter
    {
        public static Appartment ConvertAppartmentsToAppartment(Appartments appartment)
        {
            Appartment app = new Appartment()
            {
                Balance = appartment.Balance,
                Id = appartment.Id,
                Owner = appartment.Owner,
                Residents = appartment.Residents,
                Size = appartment.Size
            };
            foreach (var item in appartment.Messages)
            {
                app.Messages.Add(ConvertMessagesToMessage(item));
            }
            foreach (var item in appartment.Meters)
            {
                app.Meters.Add(ConvertMetersToMeter(item));
            }
            return app;
        }
        public static Appartments ConvertAppartmentToAppartments(Appartment appartment)
        {
            return new Appartments()
            {
                Id = appartment.Id,
                Balance = appartment.Balance,
                Owner = appartment.Owner,
                Residents = appartment.Residents,
                Size = appartment.Size
            };
        }
        public static Invoice ConvertInvoicesToInvoice(Invoices invoice)
        {
            return new Invoice()
            {
                Id = invoice.Id,
                Amount = invoice.Amount,
                Deadline = invoice.Deadline,
                Description = invoice.Description,
                Paid = invoice.Paid,
                ReadingId = invoice.ReadingId
            };
        }
        public static Invoices ConvertInvoiceToInvoices(Invoice invoice)
        {
            return new Invoices()
            {
                Amount = invoice.Amount,
                Deadline = invoice.Deadline,
                Description = invoice.Description,
                Id = invoice.Id,
                Paid = invoice.Paid,
                ReadingId = invoice.ReadingId
            };
        }
        public static Message ConvertMessagesToMessage(Messages message)
        {
            return new Message()
            {
                Id = message.Id,
                AppartmentId = message.AppartmentId,
                MessageValue = message.Message,
                ToAdmin = message.ToAdmin
            };
        }
        public static Messages ConvertMessageToMessages(Message message)
        {
            return new Messages()
            {
                Id = message.Id,
                AppartmentId = message.AppartmentId,
                Message = message.MessageValue,
                ToAdmin = message.ToAdmin
            };
        }
        public static Meter ConvertMetersToMeter(Meters meter)
        {
            Meter m = new Meter()
            {
                Id = meter.Id,
                AppartmentId = meter.AppartmentId,
                ServiceId = meter.ServiceId,
                Valid = meter.Valid
            };
            foreach (var item in meter.Readings)
            {
                m.Readings.Add(ConvertReadingsToReading(item));
            }
            return m;
        }
        public static Meters ConvertMeterToMeters(Meter meter)
        {
            return new Meters()
            {
                Id = meter.Id,
                AppartmentId = meter.AppartmentId,
                ServiceId = meter.ServiceId,
                Valid = meter.Valid
            };
        }
        public static Reading ConvertReadingsToReading(Readings reading)
        {
            Reading r = new Reading()
            {
                Id = reading.Id,
                Date = reading.Date,
                MeterId = reading.MeterId,
                ReadingAmount = reading.Reading
            };
            foreach (var item in reading.Invoices)
            {
                r.Invoices.Add(ConvertInvoicesToInvoice(item));
            }
            return r;
        }
        public static Readings ConvertReadingToReadings(Reading reading)
        {
            return new Readings()
            {
                Date = reading.Date,
                Id = reading.Id,
                MeterId = reading.MeterId,
                Reading = reading.ReadingAmount
            };
        }
        public static Service ConvertServicesToService(Services service)
        {
            return new Service()
            {
                Id = service.Id,
                CalculateByResidents = service.CalculateByResidents,
                Name = service.Name
            };
        }
        public static Services ConvertServiceToServices(Service service)
        {
            return new Services()
            {
                Id = service.Id,
                CalculateByResidents = service.CalculateByResidents,
                Name = service.Name
            };
        }
        public static User ConvertUsersToUser(Users user)
        {
            return new User()
            {
                Id = user.Id,
                AppartmentId = user.AppartmentId,
                Password = user.Password
            };
        }
        public static Users ConvertUserToUsers(User user)
        {
            return new Users()
            {
                Id = user.Id,
                AppartmentId = user.AppartmentId,
                Password = user.Password
            };
        }
    }
}
