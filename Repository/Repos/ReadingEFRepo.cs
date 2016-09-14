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
    public class ReadingEFRepo : GenericEFRepository<Readings>, IReadingRepository
    {
        public ReadingEFRepo(DbContext context) : base(context)
        {
        }

        public override Readings GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }

        public double GetLastReadingDifference(int meterId)
        {
            Readings last = GetReadingsByMeter(meterId).Last();
            Readings prev = GetReadingsByMeter(meterId).Where(akt => akt != last).Last();
            return (last.Reading - prev.Reading).Value;
        }

        public IQueryable<Readings> GetReadingsByAppartment(int appId)
        {
            return Get(akt => akt.Meters.AppartmentId == appId);
        }

        public IQueryable<Readings> GetReadingsByMeter(int meterId)
        {
            return Get(akt => akt.MeterId == meterId);
        }

        public IQueryable<Readings> GetReadingsByService(int serviceId)
        {
            return Get(akt => akt.Meters.ServiceId == serviceId);
        }
        public override void Insert(Readings newEntity)
        {
            foreach (var item in GetReadingsByMeter(newEntity.MeterId))
            {
                if (newEntity.Reading<item.Reading)
                {
                    return;
                }
            }
            newEntity.Date = DateTime.Today;
            base.Insert(newEntity);
        }
    }
}
