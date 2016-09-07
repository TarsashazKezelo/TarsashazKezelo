using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Repos
{
    interface IUserRepo
    {
        void AddReading(Readings reading);
        IQueryable<Readings> GetReadings();
        IQueryable<Invoices> GetInvoices();
        Appartments GetAppartmentData();
    }
}
