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

        private bool _valid;

        public bool Valid
        {
            get { return _valid; }
            set { Set(ref _valid, value); }
        }

        private ObservableCollection<Invoice> _invoices;

        public ObservableCollection<Invoice> Invoices
        {
            get { return _invoices; }
            set { Set(ref _invoices, value); }
        }


    }
}
