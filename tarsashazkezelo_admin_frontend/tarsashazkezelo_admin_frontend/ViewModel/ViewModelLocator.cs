using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ServiceViewModel>();
            SimpleIoc.Default.Register<AddServiceViewModel>();
            SimpleIoc.Default.Register<MainMeterViewModel>();
            SimpleIoc.Default.Register<AddMainMeterViewModel>();
            SimpleIoc.Default.Register<BuildingInvoiceViewModel>();
            SimpleIoc.Default.Register<AddBuildingInvoiceViewModel>();
            SimpleIoc.Default.Register<ApartmentViewModel>();
            SimpleIoc.Default.Register<MeterViewModel>();
            SimpleIoc.Default.Register<AddMeterViewModel>();
            SimpleIoc.Default.Register<InvoiceViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ServiceViewModel Service
        {
            get { return ServiceLocator.Current.GetInstance<ServiceViewModel>(); }
        }

        public AddServiceViewModel AddService
        {
            get { return ServiceLocator.Current.GetInstance<AddServiceViewModel>(); }
        }

        public MainMeterViewModel MainMeter
        {
            get { return ServiceLocator.Current.GetInstance<MainMeterViewModel>(); }
        }

        public AddMainMeterViewModel AddMainMeter
        {
            get { return ServiceLocator.Current.GetInstance<AddMainMeterViewModel>(); }
        }

        public BuildingInvoiceViewModel BuildingInvoice
        {
            get { return ServiceLocator.Current.GetInstance<BuildingInvoiceViewModel>(); }
        }

        public AddBuildingInvoiceViewModel AddBuildingInvoice
        {
            get { return ServiceLocator.Current.GetInstance<AddBuildingInvoiceViewModel>(); }
        }

        public ApartmentViewModel Apartment
        {
            get { return ServiceLocator.Current.GetInstance<ApartmentViewModel>(); }
        }

        public MeterViewModel Meter
        {
            get { return ServiceLocator.Current.GetInstance<MeterViewModel>(); }
        }

        public AddMeterViewModel AddMeter
        {
            get { return ServiceLocator.Current.GetInstance<AddMeterViewModel>(); }
        }

        public InvoiceViewModel Invoice
        {
            get { return ServiceLocator.Current.GetInstance<InvoiceViewModel>(); }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}