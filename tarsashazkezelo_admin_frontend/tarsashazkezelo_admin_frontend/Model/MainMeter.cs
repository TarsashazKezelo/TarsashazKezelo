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

        private float _reading;

        public float Reading
        {
            get { return _reading; }
            set { Set(ref _reading, value); }
        }

        private BuildingInvoice _buildingInvoice;

        public BuildingInvoice BuildingInvoice
        {
            get { return _buildingInvoice; }
            set { Set(ref _buildingInvoice, value); }
        }
    }
}
