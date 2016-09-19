using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Interfaces;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    public class InvoiceViewModel : ViewModelBase
    {
        private IAdminFunctions _adminFunctions=new AdminFunctions();

        public BindingList<Apartment> Apartments { get; }

        private Apartment _selectedApartment;

        public Apartment SelectedApartment
        {
            get { return _selectedApartment; }
            set { Set(ref _selectedApartment, value); }
        }

        private Invoice _selectedInvoice;

        public Invoice SelectedInvoice
        {
            get { return _selectedInvoice; }
            set { Set(ref _selectedInvoice, value); }
        }

        public ICommand PrintInvoiceButtonCommand { get; private set; }

        public void PrintInvoiceButtonMethod()
        {
            if (SelectedInvoice!=null)
            {
                PrintDialog pd = new PrintDialog();

                if (pd.ShowDialog() == true)
                {
                    pd.PrintDocument(FlowDocumentGenerator.GetPaginator(
                    FlowDocumentGenerator.GenerateDocFromInvoice(SelectedInvoice)), "Épületszámla");
                }
            }
            else
            {
                MessageBox.Show("Nincs számla kijelölve!");
            }
        }

        public InvoiceViewModel()
        {
            PrintInvoiceButtonCommand=new RelayCommand(PrintInvoiceButtonMethod);
            Apartments = _adminFunctions.GetApartments();
            foreach (Apartment apartment in Apartments)
            {
                apartment.Invoices = _adminFunctions.GetInvoicesByApartment(apartment);
            }
            Messenger.Default.Register<NotificationMessage>(this, (msg) =>
            {
                if (msg.Notification=="RefreshInvoices")
                {
                    foreach (Apartment apartment in Apartments)
                    {
                        apartment.Invoices = _adminFunctions.GetInvoicesByApartment(apartment);
                    }
                }
                else if (msg.Notification == "ClearDB")
                {
                    Apartments.Clear();
                }
            });
            Messenger.Default.Register<Apartment>(this, "PassApartment", (apartment) =>
            {
                Apartments.Add(apartment);
                apartment.Invoices = _adminFunctions.GetInvoicesByApartment(apartment);
            });
        }
        
    }
}
