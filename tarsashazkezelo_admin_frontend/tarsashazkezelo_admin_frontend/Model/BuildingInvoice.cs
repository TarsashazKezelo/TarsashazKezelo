using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_admin_frontend.Model
{
    class BuildingInvoice:ObservableObject
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { Set(() => ID, ref _id, value); }
        }

        private double _amount;

        public double Amount
        {
            get { return _amount; }
            set { Set(() => Amount, ref _amount, value); }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { Set(() => Date, ref _date, value); }
        }

        private string _desc;

        public string Description
        {
            get { return _desc; }
            set { Set(() => Description, ref _desc, value); }
        }

        

        

        
    }
}
