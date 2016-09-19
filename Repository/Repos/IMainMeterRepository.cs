using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.GenericRepos;
using Entities;

namespace Repository.Repos
{
    interface IMainMeterRepository : IRepository<MainMeters>
    {
        IQueryable<MainMeters> GetMainMetersByService(int serviceId);
        double GetReadingDifference(int id);
    }
}
