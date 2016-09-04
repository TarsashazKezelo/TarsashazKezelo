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
    class MainMeterEFRepo : GenericEFRepository<MainMeters>, IMainMeterRepository
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
    }
}
