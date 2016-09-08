using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repos;
using Entities;
using System.Data.Entity;
using System.IO;

namespace TarsashazKezelo
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext context = new TarsashazDBEntities();
            ServiceEFRepo servRepo = new ServiceEFRepo(context);
            Services serv = new Services();
            serv.CalculateByResidents = false;
            serv.Name = "valami";
            foreach (var item in servRepo.GetAll())
            {
                Console.WriteLine(item.Id);
            }
            Console.ReadLine();
            servRepo.Insert(serv);
            foreach (var item in servRepo.GetAll())
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }
}
