using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Repos
{
    interface IComplexRepositoryMethods
    {
        void Calculate(BuildingInvoices buildingInvoice);
    }
}
