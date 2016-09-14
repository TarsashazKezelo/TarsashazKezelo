using System;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_admin_frontend.Model
{
    public class BuildingInvoice:ObservableObject
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private int _mainMeterID;

        public int MainMeterID
        {
            get { return _mainMeterID; }
            set { Set(ref _mainMeterID, value); }
        }

        private double _amount;

        public double Amount
        {
            get { return _amount; }
            set { Set(ref _amount, value); }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { Set(ref _date, value); }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { Set(ref _description, value); }
        }

        private bool _valid;

        public bool Valid
        {
            get { return _valid; }
            set { Set(ref _valid, value); }
        }

        
    }
}
