using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_admin_frontend.Model
{
    public class MainMeter : ObservableObject
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private double _reading;

        public double Reading
        {
            get { return _reading; }
            set { Set(ref _reading, value); }
        }

        private ObservableCollection<BuildingInvoice> _buildingInvoices;

        public ObservableCollection<BuildingInvoice> BuildingInvoices
        {
            get { return _buildingInvoices; }
        }

        public MainMeter()
        {
            _buildingInvoices=new ObservableCollection<BuildingInvoice>();
        }
    }
}
