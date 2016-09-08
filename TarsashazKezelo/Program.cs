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
            InitDatabase db = InitDatabase.Instance;
            ServiceEFRepo sefr = new ServiceEFRepo(context);
            foreach (var item in sefr.GetAll())
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }
}
