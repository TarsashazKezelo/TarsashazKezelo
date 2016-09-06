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
            //SimpleIoc.Default.Register<MainMeterViewModel>();
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

        //public MainMeterViewModel MainMeter
        //{
        //    get { return ServiceLocator.Current.GetInstance<MainMeterViewModel>(); }
        //}

        
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}