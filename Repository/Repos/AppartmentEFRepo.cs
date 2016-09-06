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
    public class AppartmentEFRepo : GenericEFRepository<Appartments>, IAppartmentRepository
    {
        public AppartmentEFRepo(DbContext context) : base(context)
        {
        }

        public override Appartments GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }

        public void Modify(int id, string owner, int residents, double balance)
        {
            Appartments akt = GetById(id);
            if (akt == null)
            {
                throw new ArgumentException("No Data");
            }
            akt.Owner = owner;
            akt.Residents = residents;
            akt.Balance = balance;
            context.Entry<Appartments>(akt).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
