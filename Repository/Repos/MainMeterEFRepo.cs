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

        public IQueryable<MainMeters> GetMainMetersByService(int serviceId)
        {
            return Get(akt => akt.ServiceId == serviceId);
        }

        public double GetReadingDifference(int id)
        {
            MainMeters mainMeter = GetById(id);
            double? prev = null;
            if (mainMeter.Reading != null)
            {
                try
                {
                    prev = GetMainMetersByService(mainMeter.ServiceId).Where(akt => akt.Date < mainMeter.Date).ToList().Last().Reading;
                }
                catch (Exception)
                {

                }
                if (prev == null)
                {
                    return mainMeter.Reading.Value;
                }
                else
                {
                    return mainMeter.Reading.Value - prev.Value;
                }
            }
            else
            {
                return 0;
            }
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
