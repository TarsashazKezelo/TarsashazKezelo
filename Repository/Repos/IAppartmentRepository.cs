using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.GenericRepos;
using Entities;

namespace Repository.Repos
{
    interface IAppartmentRepository :IRepository<Appartments>
    {
        void Modify(int id, string owner, int residents, double balance);
        void Init(int quantity);
    }
}
