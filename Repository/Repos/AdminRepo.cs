﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using System.Collections.ObjectModel;
using Entities;
using System.Reflection;
using System.ComponentModel;

namespace Repository.Repos
{
    public class AdminRepo : IAdminRepo
    {
        static DbContext context = new TarsashazDBEntities();
        BuildingInvoiceEFRepo buildingRepo;
        MainMeterEFRepo mainMeterRepo;
        MeterEFRepo meterRepo;
        ServiceEFRepo serviceRepo;
        AppartmentEFRepo appartmentRepo;
        InvoiceEFRepo invoiceRepo;
        MessageEFRepo messageRepo;
        public AdminRepo()
        {
            InitRepos();
        }
        void InitRepos()
        {
            buildingRepo = new BuildingInvoiceEFRepo(context);
            mainMeterRepo = new MainMeterEFRepo(context);
            meterRepo = new MeterEFRepo(context);
            serviceRepo = new ServiceEFRepo(context);
            appartmentRepo = new AppartmentEFRepo(context);
            invoiceRepo = new InvoiceEFRepo(context);
            messageRepo = new MessageEFRepo(context);
        }
        public void AddBuildingInvoice(BuildingInvoices buildingInvoice)
        {
            buildingRepo.Insert(buildingInvoice);
        }
        public void AddMainMeter(MainMeters mainMeter)
        {
            mainMeterRepo.Insert(mainMeter);
        }
        public void AddMeter(Meters meter)
        {
            meterRepo.Insert(meter);
        }
        public void AddService(Services service)
        {
            serviceRepo.Insert(service);
        }
        public BindingList<Appartments> GetAppartments()
        {
            return new BindingList<Appartments>(appartmentRepo.GetAll().ToList());
        }
        public ObservableCollection<BuildingInvoices> GetBuildingInvoicesByService(int serviceId)
        {
            return new ObservableCollection<BuildingInvoices>(buildingRepo.GetBuildingInvoicesByService(serviceId));
        }
        public ObservableCollection<Invoices> GetInvoicesByAppartment(int appartmentId)
        {
            return new ObservableCollection<Invoices>(invoiceRepo.GetInvoicesByAppartment(appartmentId));
        }
        public ObservableCollection<MainMeters> GetMainMetersByService(int serviceId)
        {
            return new ObservableCollection<MainMeters>(mainMeterRepo.GetMainMetersByService(serviceId));
        }
        public ObservableCollection<Meters> GetMetersByAppartment(int appartmentId)
        {
            return new ObservableCollection<Meters>(meterRepo.GetMetersByAppartment(appartmentId));
        }
        public ObservableCollection<Services> GetServices()
        {
            return new ObservableCollection<Services>(serviceRepo.GetAll());
        }
        public Services GetServiceById(int serviceId)
        {
            return serviceRepo.GetById(serviceId);
        }
        public void ModifyAppartment(Appartments appartment)
        {
            appartmentRepo.Modify(appartment.Id, appartment.Owner, appartment.Residents.Value, appartment.Balance.Value);
        }

        public void InitDatabase()
        {
            InitDatabase init = Repository.InitDatabase.Instance;
        }

        public void AddMessage(string message, int appartmentId)
        {
            Messages newMessage = new Messages();
            newMessage.AppartmentId = appartmentId;
            newMessage.Message = message;
            newMessage.ToAdmin = false;
            messageRepo.Insert(newMessage);
        }

        public void DeleteMessage(int messageId)
        {
            messageRepo.AdminDelete(messageId);
        }

        public IQueryable<Messages> GetMessages()
        {
            return messageRepo.GetShowAdmin();
        }

        public IQueryable<Messages> GetInbox()
        {
            return messageRepo.GetToAdminShowAdmin();
        }

        public IQueryable<Messages> GetOutbox()
        {
            return messageRepo.GetFromAdminShowAdmin();
        }

        public void PaymentToBalance(int appartmentId, double amount)
        {
            appartmentRepo.GetById(appartmentId).Balance += amount;
        }

        public void PaymentFromBalance(int appartmentId, int invoiceId)
        {
            Invoices inv = invoiceRepo.GetById(invoiceId);
            appartmentRepo.GetById(appartmentId).Balance -= inv.Amount;
            inv.Paid = true;
        }
    }
}
