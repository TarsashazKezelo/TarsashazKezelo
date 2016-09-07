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
        void Delete(int id);
        void Delete(Messages messageToDelete);
        IQueryable<Messages> GetMessagesByAppartment(int appartmentId);
        IQueryable<Messages> GetToAdminByAppartment(int appartmentId);
        IQueryable<Messages> GetFromAdminByAppartment(int appartmentId);
        IQueryable<Messages> GetAllToAdmin();
        IQueryable<Messages> GetAllFromAdmin();
    }
}
