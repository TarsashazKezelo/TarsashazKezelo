using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.GenericRepos;
using Entities;

namespace Repository.Repos
{
    interface IBuildingInvoiceRepository : IRepository<BuildingInvoices>
    {
        IQueryable<BuildingInvoices> GetBuildingInvoicesByService(int serviceId);
        BuildingInvoices GetLast();
    }
}
