using Entities;
using Repository.GenericRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    interface IMessageRepository : IRepository<Messages>
    {
        IQueryable<Messages> GetByAppartmentShowUser(int appartmentId);
        IQueryable<Messages> GetToAdminByAppartmentShowUser(int appartmentId);
        IQueryable<Messages> GetFromAdminByAppartmentShowUser(int appartmentId);
        IQueryable<Messages> GetByAppartmentShowAdmin(int appartmentId);
        IQueryable<Messages> GetToAdminByAppartmentShowAdmin(int appartmentId);
        IQueryable<Messages> GetFromAdminByAppartmentShowAdmin(int appartmentId);
        IQueryable<Messages> GetToAdminShowAdmin();
        IQueryable<Messages> GetFromAdminShowAdmin();
        IQueryable<Messages> GetShowAdmin();
        void UserDelete(Messages messageToDelete);
        void UserDelete(int messageId);
        void AdminDelete(Messages messageToDelete);
        void AdminDelete(int messageId);
    }
}
