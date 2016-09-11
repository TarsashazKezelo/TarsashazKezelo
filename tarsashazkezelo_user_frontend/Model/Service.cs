using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarsashazkezelo_user_frontend.Model
{
    public class Service: ObservableObject
    {
        int _id;
        string _name;
        bool _calculateByResidents;

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

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                Set(ref _name, value);
            }
        }

        public bool CalculateByResidents
        {
            get
            {
                return _calculateByResidents;
            }

            set
            {
                Set(ref _calculateByResidents, value);
            }
        }
    }
}
