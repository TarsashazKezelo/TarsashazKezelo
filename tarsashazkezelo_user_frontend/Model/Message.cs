using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarsashazkezelo_user_frontend.Model
{
    class Message : ObservableObject
    {
        int _id;
        int _appartmentId;
        string _messageValue;
        bool _toAdmin;

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

        public string MessageValue
        {
            get
            {
                return _messageValue;
            }

            set
            {
                Set(ref _messageValue, value);
            }
        }

        public bool ToAdmin
        {
            get
            {
                return _toAdmin;
            }

            set
            {
                Set(ref _toAdmin, value);
            }
        }
    }
}
