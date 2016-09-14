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
    class MessageEFRepo : GenericEFRepository<Messages>, IMessageRepository
    {
        public MessageEFRepo(DbContext context) : base(context)
        {
        }
        public override Messages GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }
        public override void Delete(Messages entityToDelete)
        {
            if (entityToDelete.DeletedByUser && entityToDelete.DeletedByAdmin)
            {
                base.Delete(entityToDelete);
            }
        }
        public void UserDelete(Messages messageToDelete)
        {
            messageToDelete.DeletedByUser = true;
            Delete(messageToDelete);
        }
        public void AdminDelete(Messages messageToDelete)
        {
            messageToDelete.DeletedByAdmin = true;
            Delete(messageToDelete);
        }

        public IQueryable<Messages> GetByAppartmentShowUser(int appartmentId)
        {
            return Get(akt => akt.AppartmentId == appartmentId && !akt.DeletedByUser);
        }

        public IQueryable<Messages> GetToAdminByAppartmentShowUser(int appartmentId)
        {
            return GetByAppartmentShowUser(appartmentId).Where(akt => akt.ToAdmin);
        }

        public IQueryable<Messages> GetFromAdminByAppartmentShowUser(int appartmentId)
        {
            return GetByAppartmentShowUser(appartmentId).Where(akt => !akt.ToAdmin);
        }

        public IQueryable<Messages> GetByAppartmentShowAdmin(int appartmentId)
        {
            return Get(akt => akt.AppartmentId == appartmentId && !akt.DeletedByAdmin);
        }

        public IQueryable<Messages> GetToAdminByAppartmentShowAdmin(int appartmentId)
        {
            return GetToAdminShowAdmin().Where(akt => akt.AppartmentId == appartmentId);
        }

        public IQueryable<Messages> GetFromAdminByAppartmentShowAdmin(int appartmentId)
        {
            return GetFromAdminShowAdmin().Where(akt => akt.AppartmentId == appartmentId);
        }

        public IQueryable<Messages> GetToAdminShowAdmin()
        {
            return Get(akt => akt.ToAdmin && !akt.DeletedByAdmin);
        }

        public IQueryable<Messages> GetFromAdminShowAdmin()
        {
            return Get(akt => !akt.ToAdmin && !akt.DeletedByAdmin);
        }

        public void UserDelete(int messageId)
        {
            UserDelete(GetById(messageId));
        }

        public void AdminDelete(int messageId)
        {
            AdminDelete(GetById(messageId));
        }

        public IQueryable<Messages> GetShowAdmin()
        {
            return Get(akt => !akt.DeletedByAdmin);
        }
    }
}
