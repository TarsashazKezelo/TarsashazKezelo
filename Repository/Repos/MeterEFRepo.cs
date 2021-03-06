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
    public class MeterEFRepo : GenericEFRepository<Meters>, IMeterRepository
    {
        public MeterEFRepo(DbContext context) : base(context)
        {
        }

        public double GetAverageConsumption(int meterId)
        {
            ReadingEFRepo readingRepo = new ReadingEFRepo(context);
            List<Readings> readings=readingRepo.GetReadingsByMeter(meterId).ToList();
            return readings.Last().Reading.Value / readings.Count();
        }

        public override Meters GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }

        public IQueryable<Meters> GetInvalidByService(int serviceId)
        {
            return Get(akt => !akt.Valid && akt.ServiceId==serviceId);
        }
        public IQueryable<Meters> GetMetersByAppartment(int appId)
        {
            return Get(akt => akt.AppartmentId == appId);
        }

        public IQueryable<Meters> GetMetersByService(int serviceId)
        {
            return Get(akt => akt.ServiceId == serviceId);
        }

        public IQueryable<Meters> GetValidByService(int serviceId)
        {
            return Get(akt => akt.Valid&&akt.ServiceId==serviceId);
        }
    }
}
