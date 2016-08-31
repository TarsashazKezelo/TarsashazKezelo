using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_admin_frontend.Model
{
    class Service:ObservableObject
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { Set(() => ID, ref _id, value); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }

        private MainMeter _mainMeter;

        public MainMeter MainMeter
        {
            get { return _mainMeter; }
            set { Set(() => MainMeter, ref _mainMeter, value); }
        }

        

        
    }
}
