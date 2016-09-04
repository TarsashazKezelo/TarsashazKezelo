using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.GenericRepos;
using Entities;

namespace Repository.Repos
{
    interface IInvoiceRepository : IRepository<Invoices>
    {
        IQueryable<Invoices> GetInvoicesByService(int serviceId);
        IQueryable<Invoices> GetInvoicesByAppartment(int appId);
        IQueryable<Invoices> GetInvoicesByMeter(int meterId);
        Invoices GetLast();
    }
}
