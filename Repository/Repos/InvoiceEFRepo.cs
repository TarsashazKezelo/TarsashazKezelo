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
    class InvoiceEFRepo : GenericEFRepository<Invoices>, IInvoiceRepository
    {
        public InvoiceEFRepo(DbContext context) : base(context)
        {
        }

        public decimal CalculateTotal()
        {
            throw new NotImplementedException();
        }

        public override Invoices GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }
    }
}
