using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.GenericRepos;
using Entities;
using System.Data.Entity;

namespace Repository.Repos
{
    public class InvoiceEFRepo : GenericEFRepository<Invoices>, IInvoiceRepository
    {
        public InvoiceEFRepo(DbContext context) : base(context)
        {
        }
        public override Invoices GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }

        public IQueryable<Invoices> GetInvoicesByAppartment(int appId)
        {
            return Get(akt => akt.Readings.Meters.AppartmentId == appId);
        }

        public IQueryable<Invoices> GetInvoicesByMeter(int meterId)
        {
            return Get(akt => akt.Readings.MeterId == meterId);
        }

        public IQueryable<Invoices> GetInvoicesByService(int serviceId)
        {
            return Get(akt => akt.Readings.Meters.ServiceId == serviceId);
        }

        public Invoices GetLast()
        {
            return GetAll().Last();
        }
        public override void Insert(Invoices newEntity)
        {
            foreach (var item in GetAll())
            {
                if (item.ReadingId==newEntity.ReadingId)
                {
                    return;
                }
            }
            base.Insert(newEntity);
        }
    }
}
