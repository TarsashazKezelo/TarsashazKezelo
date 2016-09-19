using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.Entity;
using Repository;
using Repository.Repos;
using System.IO;

namespace TarsashazKezelo
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext context = new TarsashazDBEntities();
            ServiceEFRepo sRepo = new ServiceEFRepo(context);
            AppartmentEFRepo aRepo = new AppartmentEFRepo(context);
            MainMeterEFRepo mmRepo = new MainMeterEFRepo(context);
            BuildingInvoiceEFRepo bRepo = new BuildingInvoiceEFRepo(context);
            MeterEFRepo mRepo = new MeterEFRepo(context);
            ReadingEFRepo rRepo = new ReadingEFRepo(context);
            InvoiceEFRepo iRepo = new InvoiceEFRepo(context);
            UserEFRepo uRepo = new UserEFRepo(context);
            MessageEFRepo meRepo = new MessageEFRepo(context);
            string command = "";
            while (command != "end")
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "AddApp":
                        Appartments a = new Appartments();
                        Console.Write("owner: ");
                        a.Owner = Console.ReadLine();
                        Console.Write("residents: ");
                        a.Residents = int.Parse(Console.ReadLine());
                        Console.Write("size: ");
                        a.Size = double.Parse(Console.ReadLine());
                        Console.Write("balance: ");
                        a.Balance = double.Parse(Console.ReadLine());
                        aRepo.Insert(a);
                        Console.WriteLine("added");
                        break;
                    case "AddServ":
                        Services s = new Services();
                        Console.Write("name: ");
                        s.Name = Console.ReadLine();
                        Console.Write("calculateByResidents: ");
                        s.CalculateByResidents = bool.Parse(Console.ReadLine());
                        sRepo.Insert(s);
                        Console.WriteLine("added");
                        break;
                    case "AddMain":
                        MainMeters mm = new MainMeters();
                        Console.Write("serviceId: ");
                        foreach (var item in sRepo.GetAll())
                        {
                            Console.WriteLine("\t\t\t{0} - {1}", item.Id, item.Name);
                        }
                        mm.ServiceId = int.Parse(Console.ReadLine());
                        Console.Write("reading: ");
                        mm.Reading = double.Parse(Console.ReadLine());
                        mmRepo.Insert(mm);
                        Console.WriteLine("added");
                        break;
                    case "AddBInv":
                        BuildingInvoices b = new BuildingInvoices();
                        Console.Write("meterId: ");
                        foreach (var item in mRepo.GetAll())
                        {
                            Console.WriteLine("\t\t\t{0} - {1} appartment, {2} service", item.Id, item.ServiceId, item.AppartmentId);
                        }
                        b.MainMeterId = int.Parse(Console.ReadLine());
                        Console.Write("amount: ");
                        b.Amount = int.Parse(Console.ReadLine());
                        Console.Write("description: ");
                        b.Description = Console.ReadLine();
                        bRepo.Insert(b);
                        Console.WriteLine("added");
                        break;
                    case "AddMeter":
                        Meters m = new Meters();
                        Console.Write("appartmentId: ");
                        foreach (var item in aRepo.GetAll())
                        {
                            Console.WriteLine("\t\t\t{0} - {1}", item.Id, item.Owner);
                        }
                        m.AppartmentId = int.Parse(Console.ReadLine());
                        Console.Write("serviceId: ");
                        foreach (var item in sRepo.GetAll())
                        {
                            Console.WriteLine("\t\t\t{0} - {1}", item.Id, item.Name);
                        }
                        m.ServiceId = int.Parse(Console.ReadLine());
                        Console.Write("valid: ");
                        m.Valid = bool.Parse(Console.ReadLine());
                        mRepo.Insert(m);
                        Console.WriteLine("added");
                        break;
                    case "AddReading":
                        Readings r = new Readings();
                        Console.Write("meterId: ");
                        foreach (var item in mRepo.GetAll())
                        {
                            Console.WriteLine("\t\t\t{0} - {1} appartment, {2} service", item.Id, item.AppartmentId, item.ServiceId);
                        }
                        r.MeterId = int.Parse(Console.ReadLine());
                        Console.Write("reading: ");
                        r.Reading = double.Parse(Console.ReadLine());
                        rRepo.Insert(r);
                        Console.WriteLine("added");
                        break;
                    case "AddMessage":
                        Messages me = new Messages();
                        Console.Write("appartmentId: ");
                        foreach (var item in aRepo.GetAll())
                        {
                            Console.WriteLine("\t\t\t{0} - {1}", item.Id, item.Owner);
                        }
                        me.AppartmentId = int.Parse(Console.ReadLine());
                        Console.Write("message: ");
                        me.Message = Console.ReadLine();
                        meRepo.Insert(me);
                        Console.WriteLine("added");
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Services: ");
            foreach (var i in sRepo.GetAll())
            {
                Console.Write("{0}\t\t", i.Name);
            }
            Console.WriteLine("Main meters: ");
            foreach (var i in mmRepo.GetAll())
            {
                Console.Write("{0} - {1}\t\t", i.ServiceId, i.Date);
            }
            Console.WriteLine("Building invoices: ");
            foreach (var i in bRepo.GetAll())
            {
                Console.Write("{0} - {1}\t\t", i.Amount, i.Date);
            }
            Console.WriteLine("Appartments: ");
            foreach (var i in aRepo.GetAll())
            {
                Console.Write("{0}: {1}\t\t", i.Id, i.Owner);
            }
            Console.WriteLine("Meters: ");
            foreach (var i in mRepo.GetAll())
            {
                Console.Write("{0}->{1}\t\t", i.ServiceId, i.AppartmentId);
                Console.WriteLine("Readings: ");
                foreach (var ii in rRepo.GetReadingsByMeter(i.Id))
                {
                    Console.Write("{0} - {1}\t\t", ii.Reading, ii.Date);
                }
                Console.WriteLine("Invoices: ");
                foreach (var ii in iRepo.GetInvoicesByMeter(i.Id))
                {
                    Console.Write("{0} - {1}\t\t", ii.Amount, ii.Deadline);
                }
            }
            Console.WriteLine("Messages: ");
            foreach (var i in meRepo.GetAll())
            {
                Console.Write("{0}\t\t", i.Message);
            }
            Console.WriteLine("Users: ");
            foreach (var i in uRepo.GetAll())
            {
                Console.Write("{0}\t\t", i.AppartmentId);
            }

            //Console.WriteLine("Services");
            //foreach (var item in sRepo.GetAll())
            //{
            //    Console.WriteLine("{0} - {1} - {2}", item.Id, item.Name, item.CalculateByResidents);
            //    Console.WriteLine("\tMainMeters");
            //    foreach (var i in item.MainMeters)
            //    {
            //        Console.WriteLine("\t{0} - {1} - {2} - {3}", i.ServiceId, i.Id, i.Reading, i.Date);
            //        Console.WriteLine("\t\tBuildingInvoices");
            //        foreach (var ii in i.BuildingInvoices)
            //        {
            //            Console.WriteLine("\t\t{0} - {1} - {2} - {3}", ii.MainMeterId, ii.Id, ii.Date, ii.Amount);
            //        }
            //    }
            //    Console.WriteLine("\tMeters");
            //    foreach (var i in item.Meters)
            //    {
            //        Console.WriteLine("\t{0} - {1} - {2} - {3}", i.ServiceId, i.Id, i.AppartmentId, i.Valid);
            //        Console.WriteLine("\t\tReadings");
            //        foreach (var ii in i.Readings)
            //        {
            //            Console.WriteLine("\t\t{0} - {1} - {2} - {3}", ii.MeterId, ii.Id, ii.Reading, ii.Date);
            //            Console.WriteLine("\t\t\tInvoices");
            //            foreach (var iii in ii.Invoices)
            //            {
            //                Console.WriteLine("\t\t\t{0} - {1} - {2} - {3}", iii.ReadingId, iii.Id, iii.Amount, iii.Paid);
            //            }
            //        }
            //    }
            //}
            //Console.WriteLine("Appartments");
            //foreach (var i in aRepo.GetAll())
            //{
            //    Console.WriteLine("{0} - {1} - {2} - {3} - {4}", i.Id, i.Owner, i.Size, i.Residents, i.Balance);
            //    Console.WriteLine("\tMeters");
            //    foreach (var ii in i.Meters)
            //    {
            //        Console.WriteLine("\t{0} - {1} - {2} - {3}", ii.AppartmentId, ii.Id, ii.ServiceId, ii.Valid);
            //        Console.WriteLine("\t\tReadings");
            //        foreach (var iii in ii.Readings)
            //        {
            //            Console.WriteLine("\t\t{0} - {1} - {2} - {3}", iii.MeterId, iii.Id, iii.Reading, iii.Date);
            //            Console.WriteLine("\t\t\tInvoices");
            //            foreach (var iiii in iii.Invoices)
            //            {
            //                Console.WriteLine("\t\t\t{0} - {1} - {2} - {3} - {4}", iiii.ReadingId, iiii.Id, iiii.Deadline, iiii.Amount, iiii.Paid);
            //            }
            //        }
            //    }
            //    Console.WriteLine("\tMessages");
            //    foreach (var ii in i.Messages)
            //    {
            //        Console.WriteLine("\t{0} - {1} - {2} - {3} - {4} - {5}", ii.AppartmentId, ii.Id, ii.Message, ii.ToAdmin, ii.DeletedByAdmin, ii.DeletedByUser);
            //    }
            //    Console.WriteLine("\tUsers");
            //    foreach (var ii in i.Users)
            //    {
            //        Console.WriteLine("\t{0} - {1} - {2}", ii.AppartmentId, ii.Id, ii.Password);
            //    }
            //}
            //Console.WriteLine("MainMeters");
            //foreach (var i in mmRepo.GetAll())
            //{
            //    Console.WriteLine("{0} - {1} - {2} - {3}", i.ServiceId, i.Id, i.Reading, i.Date);
            //}
            //Console.WriteLine("BuildingInvoices");
            //foreach (var i in bRepo.GetAll())
            //{
            //    Console.WriteLine("{0} - {1} - {2} - {3}", i.MainMeterId, i.Id, i.Date, i.Amount);
            //}
            //Console.WriteLine("Meters");
            //foreach (var i in mRepo.GetAll())
            //{
            //    Console.WriteLine("{0} - {1} - {2} - {3}", i.ServiceId, i.Id, i.AppartmentId, i.Valid);
            //}
            //Console.WriteLine("Readings");
            //foreach (var i in rRepo.GetAll())
            //{
            //    Console.WriteLine("{0} - {1} - {2} - {3}", i.MeterId, i.Id, i.Reading, i.Date);
            //}
            //Console.WriteLine("Invoices");
            //foreach (var i in iRepo.GetAll())
            //{
            //    Console.WriteLine("{0} - {1} - {2} - {3} - {4}", i.ReadingId, i.Id, i.Deadline, i.Amount, i.Paid);
            //}
            //Console.WriteLine("Messages");
            //foreach (var i in meRepo.GetAll())
            //{
            //    Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", i.AppartmentId, i.Id, i.Message, i.ToAdmin, i.DeletedByAdmin, i.DeletedByUser);
            //}
            //Console.WriteLine("Users");
            //foreach (var i in uRepo.GetAll())
            //{
            //    Console.WriteLine("{0} - {1} - {2}", i.AppartmentId, i.Id, i.Password);
            //}

            //Console.ReadLine();
        }
    }
}
