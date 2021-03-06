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
    public class ReadingEFRepo : GenericEFRepository<Readings>, IReadingRepository
    {
        public ReadingEFRepo(DbContext context) : base(context)
        {
        }
        public override Readings GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }

        public double GetLastValue(int meterId)
        {
            return GetReadingsByMeter(meterId).ToList().Last().Reading.Value;
        }

        public double GetReadingDifference(int id)
        {
            Readings reading = GetById(id);
            double? prev = null;
            if (reading.Reading != null)
            {
                try
                {
                    prev = GetReadingsByMeter(reading.MeterId).Where(akt => akt.Id < id).ToList().Last().Reading;
                }
                catch (Exception)
                {

                }
                if (prev == null)
                {
                    return reading.Reading.Value;
                }
                else
                {
                    return reading.Reading.Value - prev.Value;
                }
            }
            else
            {
                return 0;
            }
        }

        public IQueryable<Readings> GetReadingsByAppartment(int appId)
        {
            return Get(akt => akt.Meters.AppartmentId == appId);
        }

        public IQueryable<Readings> GetReadingsByMeter(int meterId)
        {
            return Get(akt => akt.MeterId == meterId);
        }

        public IQueryable<Readings> GetReadingsByService(int serviceId)
        {
            return Get(akt => akt.Meters.ServiceId == serviceId);
        }
        public override void Insert(Readings newEntity)
        {
            foreach (var item in GetReadingsByMeter(newEntity.MeterId))
            {
                if (newEntity.Reading < item.Reading)
                {
                    return;
                }
            }
            newEntity.Date = DateTime.Today;
            base.Insert(newEntity);
        }

        public void LateInsert(DateTime date, int meterId)
        {
            MeterEFRepo meterRepo = new MeterEFRepo(context);

            if (!meterRepo.GetById(meterId).Valid)
            {
                base.Insert(new Readings() { Date = date, MeterId = meterId });
            }
            else
            {
                Readings reading = new Readings() { Date = date, MeterId = meterId };
                reading.Reading = GetLastValue(meterId) + meterRepo.GetAverageConsumption(meterId);
                base.Insert(reading);
            }
        }
    }
}
