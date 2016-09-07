﻿using Entities;
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

        public void Delete(Messages messageToDelete)
        {
            context.Set<Messages>().Remove(messageToDelete);
            context.Entry<Messages>(messageToDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Messages messageToDelete = GetById(id);
            if (messageToDelete == null)
            {
                throw new ArgumentException("No Data");
            }
            Delete(messageToDelete);
        }

        public IQueryable<Messages> GetAllFromAdmin()
        {
            return Get(akt => !akt.ToAdmin);
        }

        public IQueryable<Messages> GetAllToAdmin()
        {
            return Get(akt => akt.ToAdmin);
        }

        public override Messages GetById(int id)
        {
            return Get(akt => akt.Id == id).SingleOrDefault();
        }

        public IQueryable<Messages> GetFromAdminByAppartment(int appartmentId)
        {
            return GetMessagesByAppartment(appartmentId).Where(akt => !akt.ToAdmin);
        }

        public IQueryable<Messages> GetMessagesByAppartment(int appartmentId)
        {
            return Get(akt => akt.AppartmentId == appartmentId);
        }

        public IQueryable<Messages> GetToAdminByAppartment(int appartmentId)
        {
            return GetMessagesByAppartment(appartmentId).Where(akt => akt.ToAdmin);
        }
    }
}