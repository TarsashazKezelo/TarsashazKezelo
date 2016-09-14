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
    public class MainMeterEFRepo : GenericEFRepository<MainMeters>, IMainMeterRepository
    {
        public MainMeterEFRepo(DbContext context) : base(context)
        {
        }

        public override MainMeters GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }

        public double GetLastReadingDifference(int serviceId)
        {
            MainMeters last = GetMainMetersByService(serviceId).Last();
            MainMeters prev = GetMainMetersByService(serviceId).Where(akt=>akt!=last).Last();
            return (last.Reading - prev.Reading).Value;
        }

        public IQueryable<MainMeters> GetMainMetersByService(int serviceId)
        {
            return Get(akt => akt.ServiceId == serviceId);
        }
        public override void Insert(MainMeters newEntity)
        {
            foreach (var item in GetMainMetersByService(newEntity.ServiceId))
            {
                if (newEntity.Reading < item.Reading)
                {
                    return;
                }
            }
            newEntity.Date = DateTime.Today;
            base.Insert(newEntity);
        }
    }
}
