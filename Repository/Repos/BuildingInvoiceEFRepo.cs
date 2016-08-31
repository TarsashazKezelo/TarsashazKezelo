﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.GenericRepos;
using Entities;
using System.Data.Entity;

namespace Repository.Repos
{
    class BuildingInvoiceEFRepo : GenericEFRepository<BuildingInvoices>, IBuildingInvoiceRepository
    {
        public BuildingInvoiceEFRepo(DbContext context) : base(context)
        {
        }

        public override BuildingInvoices GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }
    }
}
