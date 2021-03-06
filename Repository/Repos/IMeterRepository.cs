﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.GenericRepos;
using Entities;

namespace Repository.Repos
{
    interface IMeterRepository : IRepository<Meters>
    {
        IQueryable<Meters> GetMetersByAppartment(int appId);
        IQueryable<Meters> GetMetersByService(int serviceId);
        IQueryable<Meters> GetValidByService(int serviceId);
        IQueryable<Meters> GetInvalidByService(int serviceId);
        double GetAverageConsumption(int meterId);
    }
}
