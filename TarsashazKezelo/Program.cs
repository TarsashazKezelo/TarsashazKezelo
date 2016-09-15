using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.Entity;
using Repository;
using Repository.Repos;
using System.IO;

namespace TarsashazKezelo
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext context = new TarsashazDBEntities();
            InvoiceEFRepo invRepo = new InvoiceEFRepo(context);
            IQueryable<Invoices> invoices = invRepo.GetAll();
            foreach (var item in invoices)
            {
                Console.WriteLine("{0} - {1}", item.Readings.Meters.AppartmentId, item.Amount);
            }
            Console.WriteLine("finished");
            Console.ReadLine();
        }
    }
}
