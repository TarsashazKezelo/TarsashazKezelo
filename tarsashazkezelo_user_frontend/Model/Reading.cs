using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarsashazkezelo_user_frontend.Model
{
    public class Reading : ObservableObject
    {
        int _id;
        int _meterId;
        double? _readingAmount;
        DateTime _date;
        ObservableCollection<Invoice> _invoices;

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

        public int MeterId
        {
            get
            {
                return _meterId;
            }

            set
            {
                Set(ref _meterId, value);
            }
        }

        public double? ReadingAmount
        {
            get
            {
                return _readingAmount;
            }

            set
            {
                Set(ref _readingAmount, value);
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                Set(ref _date, value);
            }
        }

        public ObservableCollection<Invoice> Invoices
        {
            get
            {
                return _invoices;
            }

            set
            {
                Set(ref _invoices, value);
            }
        }
    }
}
