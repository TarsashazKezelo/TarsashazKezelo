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
            Console.WriteLine(apprepo.GetById(1).Owner);
            Appartments app = new Appartments();
            app.Owner = "valaki nagyon más";
            app.Residents = 3;
            app.Size = 3;
            apprepo.Insert(app);
            Console.ReadLine();
        }
    }
}
