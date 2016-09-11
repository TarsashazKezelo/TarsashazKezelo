using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarsashazkezelo_user_frontend.Model
{
    public class Meter : ObservableObject
    {
        int _id;
        int _appartmentId;
        int _serviceId;
        bool _valid;
        ObservableCollection<Reading> _readings;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                Set(ref _id, value);
            }
        }

        public int AppartmentId
        {
            get
            {
                return _appartmentId;
            }

            set
            {
                Set(ref _appartmentId, value);
            }
        }

        public int ServiceId
        {
            get
            {
                return _serviceId;
            }

            set
            {
                Set(ref _serviceId, value);
            }
        }

        public bool Valid
        {
            get
            {
                return _valid;
            }

            set
            {
                Set(ref _valid, value);
            }
        }

        public ObservableCollection<Reading> Readings
        {
            get
            {
                return _readings;
            }

            set
            {
                Set(ref _readings, value);
            }
        }
    }
}
