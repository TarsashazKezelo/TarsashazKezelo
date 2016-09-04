using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.GenericRepos;
using Entities;

namespace Repository.Repos
{
    interface IReadingRepository : IRepository<Readings>
    {
        IQueryable<Readings> GetReadingsByAppartment(int appId);
        IQueryable<Readings> GetReadingsByService(int serviceId);
        IQueryable<Readings> GetReadingsByMeter(int meterId);
    }
}
