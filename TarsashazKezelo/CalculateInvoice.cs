using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository.Repos;
using System.Data.Entity;

namespace TarsashazKezelo
{
    class CalculateInvoice
    {
        static string connString= @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=F:\doksik\Schonherz\project\TarsashazKezelo\Entities\TarsashazDB.mdf;
Integrated Security=True";
        static DbContext context = new DbContext(connString);
        static AppartmentEFRepo AppRepo;
        static BuildingInvoiceEFRepo BInvRepo;
        static InvoiceEFRepo InvRepo;
        static MainMeterEFRepo MMRepo;
        static MeterEFRepo MeterRepo;
        static ReadingEFRepo ReadingRepo;
        static ServiceEFRepo ServRepo;
        static void InitRepos()
        {
            AppRepo = new AppartmentEFRepo(context);
            BInvRepo = new BuildingInvoiceEFRepo(context);
            InvRepo = new InvoiceEFRepo(context);
            MMRepo = new MainMeterEFRepo(context);
            ReadingRepo = new ReadingEFRepo(context);
            ServRepo = new ServiceEFRepo(context);
        }
        public void Calculate()
        {
            if(BInvRepo.GetLast().MainMeters.Date>InvRepo.GetLast().Readings.Date)
            {
                Calculate(BInvRepo.GetLast());
            }
        }
        public void Calculate(BuildingInvoices bInv)
        {
            MainMeters main = bInv.MainMeters;
            MainMeters prev = MMRepo.Get(akt => akt.Id < main.Id).OrderBy(x=>x.Id).Last();
            int servId = main.ServiceId;
            List<Meters> validMeters = MeterRepo.Get(akt => akt.ServiceId == servId&&akt.Valid).ToList();
            List<Meters> withoutMeters = MeterRepo.Get(akt => akt.ServiceId == servId&&!akt.Valid).ToList();
            if (main.Reading!=null)
            {
                double unit = double.Parse((bInv.Amount / (main.Reading - prev.Reading)).ToString());
                foreach (var item in validMeters)
                {

                }
            }
            else
            {

            }
        }
    }
}
