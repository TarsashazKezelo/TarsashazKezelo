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
    public class MeterEFRepo : GenericEFRepository<Meters>, IMeterRepository
    {
        public MeterEFRepo(DbContext context) : base(context)
        {
        }

        public void Delete(Meters meterToDelete)
        {
            context.Set<Meters>().Remove(meterToDelete);
            context.Entry<Meters>(meterToDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Meters meterToDelete = GetById(id);
            if (meterToDelete == null)
            {
                throw new ArgumentException("No Data");
            }
            Delete(meterToDelete);
        }

        public override Meters GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }

        public IQueryable<Meters> GetInvalid()
        {
            return Get(akt => !akt.Valid);
        }

        public IQueryable<Meters> GetMetersByAppartment(int appId)
        {
            return Get(akt => akt.AppartmentId == appId);
        }

        public IQueryable<Meters> GetMetersByService(int serviceId)
        {
            return Get(akt => akt.ServiceId == serviceId);
        }

        public IQueryable<Meters> GetValid()
        {
            return Get(akt => akt.Valid);
        }
    }
}
