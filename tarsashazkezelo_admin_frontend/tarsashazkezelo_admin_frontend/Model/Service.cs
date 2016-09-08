using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_admin_frontend.Model
{
    public class Service : ObservableObject
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

        private bool _calculateByResidents;

        public bool CalculateByResidents
        {
            get { return _calculateByResidents; }
            set { Set(ref _calculateByResidents, value); }
        }

        private ObservableCollection<MainMeter> _mainMeters;

        public ObservableCollection<MainMeter> MainMeters
        {
            get { return _mainMeters; }
            set { Set(ref _mainMeters, value); }
        }

        public Service()
        {
            _mainMeters=new ObservableCollection<MainMeter>();
        }
    }
}
