using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Entities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Interfaces;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    public class MeterViewModel : ViewModelBase
    {
        private IAdminFunctions _adminFunctions=new AdminFunctions();

        public BindingList<Apartment> Apartments { get; }

        private Apartment _selectedApartment;

        public Apartment SelectedApartment
        {
            get { return _selectedApartment; }
            set { Set(ref _selectedApartment, value); }
        }

        private Meter _selectedMeter;

        public Meter SelectedMeter
        {
            get { return _selectedMeter; }
            set
            {
                Set(ref _selectedMeter, value);
                SelectedMeterService = _adminFunctions.GetServiceById(_selectedMeter.ServiceID);
            }
        }

        private Service _selectedMeterService;

        public Service SelectedMeterService
        {
            get { return _selectedMeterService; }
            set { Set(ref _selectedMeterService, value); }
        }

        public ICommand AddMeterCommand { get; private set; }

        public void AddMeterMethod()
        {
            Meter newMeter=new Meter() {AppartmentID = SelectedApartment.ID};
            Messenger.Default.Send(newMeter, "AddMeterWindow");
        }

        public MeterViewModel()
        {
            AddMeterCommand=new RelayCommand(AddMeterMethod);
            Apartments = _adminFunctions.GetApartments();
            foreach (Apartment apartment in Apartments)
            {
                apartment.Meters = _adminFunctions.GetMetersByApartment(apartment);
            }
            Messenger.Default.Register<Meter>(this, "MeterAdded", (meter) =>
            {
                _adminFunctions.AddMeter(meter);
                Meter m = _adminFunctions.GetMetersByApartment(SelectedApartment).Last();
                SelectedApartment.Meters.Add(m);
            });
            Messenger.Default.Register<NotificationMessage>(this, (msg) =>
            {
                if (msg.Notification == "ClearDB")
                {
                    Apartments.Clear();
                }
            });
            Messenger.Default.Register<Apartment>(this, "PassApartment", (apartment) =>
            {
                Apartments.Add(apartment);
                apartment.Meters = _adminFunctions.GetMetersByApartment(apartment);
            });

        }
    }
}
