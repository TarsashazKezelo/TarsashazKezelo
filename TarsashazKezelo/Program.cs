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
            AppartmentEFRepo apprepo = new AppartmentEFRepo(context);
            apprepo.DeleteAll();
            foreach (var item in apprepo.GetAll())
            {
                Console.WriteLine(item.Id);
            }
            Console.ReadLine();
        }
    }
}
