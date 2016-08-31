using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_admin_frontend.Model
{
    class MainMeter : ObservableObject
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { Set(() => ID, ref _id, value); }
        }

        private double _reading;

        public double Reading
        {
            get { return _reading; }
            set { Set(() => Reading, ref _reading, value); }
        }

        private ObservableCollection<BuildingInvoice> _buildingInvoices;

        public ObservableCollection<BuildingInvoice> BuildingInvoices
        {
            get { return _buildingInvoices; }
            set { Set(() => BuildingInvoices, ref _buildingInvoices, value); }
        }



        

        



        
    }
}
