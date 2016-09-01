using System;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_admin_frontend.Model
{
    public class Service:ObservableObject
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private MainMeter _mainMeter;

        public MainMeter MainMeter
        {
            get { return _mainMeter; }
            set { Set(ref _mainMeter, value); }
        }
    }
}
