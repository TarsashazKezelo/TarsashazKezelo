using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_user_frontend.Model
{
    public class Invoice : ObservableObject
    {
        int _id;
        int _readingId;
        double _amount;
        DateTime _deadline;
        bool _paid;
        string _description;

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

        public int ReadingId
        {
            get
            {
                return _readingId;
            }

            set
            {
                Set(ref _readingId, value);
            }
        }

        public double Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                Set(ref _amount, value);
            }
        }

        public DateTime Deadline
        {
            get
            {
                return _deadline;
            }

            set
            {
                Set(ref _deadline, value);
            }
        }

        public bool Paid
        {
            get
            {
                return _paid;
            }

            set
            {
                Set(ref _paid, value);
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                Set(ref _description, value);
            }
        }
    }
}
