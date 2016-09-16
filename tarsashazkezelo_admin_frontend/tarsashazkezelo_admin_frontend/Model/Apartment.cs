using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_admin_frontend.Model
{
    public class Apartment : ObservableObject
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private string _owner;

        public string Owner
        {
            get { return _owner; }
            set { Set(ref _owner, value); }
        }

        private double? _size;

        public double? Size
        {
            get { return _size; }
            set { Set(ref _size, value); }
        }

        private int? _residents;

        public int? Residents
        {
            get { return _residents; }
            set { Set(ref _residents, value); }
        }

        private double? _balance;

        public double? Balance
        {
            get { return _balance; }
            set { Set(ref _balance, value); }
        }

        private ObservableCollection<Meter> _meters;

        public ObservableCollection<Meter> Meters
        {
            get { return _meters; }
            set { Set(ref _meters, value); }
        }

        private ObservableCollection<Invoice> _invoices;

        public ObservableCollection<Invoice> Invoices
        {
            get { return _invoices; }
            set { Set(ref _invoices, value); }
        }
    }
}
