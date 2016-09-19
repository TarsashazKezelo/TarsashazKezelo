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
    public class BuildingInvoiceEFRepo : GenericEFRepository<BuildingInvoices>, IBuildingInvoiceRepository
    {
        ComplexRepositoryMethods repo;
        public BuildingInvoiceEFRepo(DbContext context) : base(context)
        {
            repo = new ComplexRepositoryMethods(context);
        }

        public IQueryable<BuildingInvoices> GetBuildingInvoicesByService(int serviceId)
        {
            return Get(akt => akt.MainMeters.ServiceId == serviceId);
        }

        public override BuildingInvoices GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }

        public BuildingInvoices GetLast()
        {
            return GetAll().Last();
        }
        public override void Insert(BuildingInvoices newEntity)
        {
            foreach (var item in GetAll())
            {
                if (item.MainMeterId==newEntity.MainMeterId)
                {
                    return;
                }
            }
            newEntity.Date = DateTime.Today;
            repo.Calculate(newEntity);
            base.Insert(newEntity);
        }
    }
}
