using Entities;
using Repository.GenericRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    interface IUserRepository : IRepository<Users>
    {
        void ModifyPassword(int id, string oldPassword, string newPassword);
        bool Compare(int id, string password);
        Users GetByAppartmentId(int appartmentId);
    }
}
