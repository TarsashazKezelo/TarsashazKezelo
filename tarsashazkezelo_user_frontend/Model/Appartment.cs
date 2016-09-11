using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarsashazkezelo_user_frontend.Model
{
    class Appartment : ObservableObject
    {
        int _id;
        string _owner;
        int? _residents;
        double? _size;
        double? _balance;
        ObservableCollection<Meter> _meters;
        ObservableCollection<Message> _messages;
        User _user;

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

        public string Owner
        {
            get
            {
                return _owner;
            }

            set
            {
                Set(ref _owner, value);
            }
        }

        public int? Residents
        {
            get
            {
                return _residents;
            }

            set
            {
                Set(ref _residents, value);
            }
        }

        public double? Size
        {
            get
            {
                return _size;
            }

            set
            {
                Set(ref _size, value);
            }
        }

        public double? Balance
        {
            get
            {
                return _balance;
            }

            set
            {
                Set(ref _balance, value);
            }
        }

        public ObservableCollection<Meter> Meters
        {
            get
            {
                return _meters;
            }

            set
            {
                Set(ref _meters, value);
            }
        }

        public ObservableCollection<Message> Messages
        {
            get
            {
                return _messages;
            }

            set
            {
                Set(ref _messages, value);
            }
        }
    }
}
