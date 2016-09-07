using Entities;
using Repository.GenericRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository.Repos
{
    class UserEFRepo : GenericEFRepository<Users>, IUserRepository
    {
        public UserEFRepo(DbContext context) : base(context)
        {
        }

        public bool Compare(int id, string password)
        {
            if (password==GetById(id).Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(Users userToDelete)
        {
            context.Set<Users>().Remove(userToDelete);
            context.Entry<Users>(userToDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Users userToDelete = GetById(id);
            if (userToDelete == null)
            {
                throw new ArgumentException("No Data");
            }
            Delete(userToDelete);
        }

        public override Users GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }

        public void Modify(int id, string oldPassword, string newPassword)
        {
            Users akt = GetById(id);
            if (Compare(id, oldPassword))
            {
                akt.Password = newPassword;
                context.Entry<Users>(akt).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public override void Insert(Users newEntity)
        {
            foreach (var item in GetAll())
            {
                if (item.AppartmentId==newEntity.AppartmentId)
                {
                    return;
                }
            }
            base.Insert(newEntity);
        }
    }
}
