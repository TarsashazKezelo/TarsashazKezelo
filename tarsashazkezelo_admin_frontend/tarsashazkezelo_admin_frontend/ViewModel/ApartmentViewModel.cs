using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Entities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Interfaces;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    public class ApartmentViewModel : ViewModelBase
    {
        public BindingList<Apartment> Apartments { get; }

        private Apartment _selectedApartment;

        public Apartment SelectedApartment
        {
            get { return _selectedApartment; }
            set { Set(ref _selectedApartment, value); }
        }

        private IAdminFunctions _adminFunctions = new AdminFunctions();

        public ICommand ModifyApartmentCommand { get; private set; }

        public void ModifyApartmentMethod()
        {
            if (SelectedApartment != null)
            {
                _adminFunctions.ModifyApartment(SelectedApartment);
            }
            else
            {
                MessageBox.Show("Nincs lakás kiválasztva");
            }

        }

        public ApartmentViewModel()
        {
            Apartments = _adminFunctions.GetApartments();
            ModifyApartmentCommand = new RelayCommand(ModifyApartmentMethod);
            Messenger.Default.Register<NotificationMessage>(this, (msg) =>
            {
                if (msg.Notification == "ClearDB")
                {
                    Apartments.Clear();
                }
                if (msg.Notification == "InitDB")
                {
                    BindingList<Apartment> newCollection = _adminFunctions.GetApartments();
                    foreach (Apartment apartment in newCollection)
                    {
                        Apartments.Add(apartment);
                        Messenger.Default.Send(apartment, "PassApartment");
                    }
                }
            });
        }
    }
}
