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
    public class ServiceEFRepo : GenericEFRepository<Services>, IServiceRepository
    {
        public ServiceEFRepo(DbContext context) : base(context)
        {
        }

        public override Services GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }
    }
}
