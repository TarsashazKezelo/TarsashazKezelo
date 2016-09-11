using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarsashazkezelo_user_frontend.Model
{
    class User : ObservableObject
    {
        int _id;
        int _appartmentId;
        string _password;

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

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                Set(ref _password, value);
            }
        }
    }
}
