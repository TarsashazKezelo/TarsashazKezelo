using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_admin_frontend.Model
{
    public class Invoice : ObservableObject
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private float _amount;

        public float Amount
        {
            get { return _amount; }
            set { Set(ref _amount, value); }
        }

        private DateTime _deadLine;

        public DateTime DeadLine
        {
            get { return _deadLine; }
            set { Set(ref _deadLine, value); }
        }

        
    }
}
