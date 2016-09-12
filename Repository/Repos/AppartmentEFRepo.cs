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
            if (owner != akt.Owner)
            {
                UserEFRepo userRepo = new UserEFRepo(context);
                Users oldUser = akt.Users.SingleOrDefault();
                userRepo.Delete(oldUser);
                if (owner!=null)
                {
                    Users newUser = new Users();
                    newUser.AppartmentId = id;
                    newUser.Password = "";
                    userRepo.Insert(newUser);
                }
            }
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
        public override void Insert(Appartments newEntity)
        {
            base.Insert(newEntity);
            if (newEntity.Owner != null)
            {
                UserEFRepo userRepo = new UserEFRepo(context);
                Users newUser = new Users();
                newUser.AppartmentId = newEntity.Id;
                newUser.Password = "";
                userRepo.Insert(newUser);
            }
        }

        public void Init(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Insert(new Appartments());
            }
        }
    }
}
