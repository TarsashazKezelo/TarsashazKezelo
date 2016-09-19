using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_admin_frontend.Model
{
    public class Meter : ObservableObject
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private int _appartmentID;

        public int AppartmentID
        {
            get { return _appartmentID; }
            set { Set(ref _appartmentID, value); }
        }

        private int _serviceID;

        public int ServiceID
        {
            get { return _serviceID; }
            set { Set(ref _serviceID, value); }
        }

        private bool _valid;

        public bool Valid
        {
            get { return _valid; }
            set { Set(ref _valid, value); }
        }

        private string _serviceName;

        public string ServiceName
        {
            get { return _serviceName; }
            set { Set(ref _serviceName, value); }
        }

        
    }
}
