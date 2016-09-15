using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Interfaces;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IAdminFunctions _adminFunctions;

        private bool _serviceVisibility;

        public bool ServiceVisibility
        {
            get { return _serviceVisibility; }
            set { Set(ref _serviceVisibility, value); }
        }

        public ICommand ServiceButtonCommand { get; private set; }

        public void ServiceButtonMethod()
        {
            HideAll();
            ServiceVisibility = true;
        }

        private bool _mainMeterVisibility;

        public bool MainMeterVisibility
        {
            get { return _mainMeterVisibility; }
            set { Set(ref _mainMeterVisibility, value); }
        }

        public ICommand MainMeterButtonCommand { get; private set; }

        public void MainMeterButtonMethod()
        {
            HideAll();
            MainMeterVisibility = true;
        }

        private bool _buildingInvoiceVisibility;

        public bool BuildingInvoiceVisibility
        {
            get { return _buildingInvoiceVisibility; }
            set { Set( ref _buildingInvoiceVisibility, value); }
        }

        public ICommand BuildingInvoiceButtonCommand { get; private set; }

        public void BuildingInvoiceButtonMethod()
        {
            HideAll();
            BuildingInvoiceVisibility = true;
        }

        public ICommand InitDatabaseButtonCommand { get; private set; }

        public void InitDatabaseButtonMethod()
        {
            _adminFunctions.InitDatabase();
        }

        private void HideAll()
        {
            ServiceVisibility = false;
            BuildingInvoiceVisibility = false;
            MainMeterVisibility = false;
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _adminFunctions = new AdminFunctions();
            ServiceButtonCommand = new RelayCommand(ServiceButtonMethod);
            MainMeterButtonCommand = new RelayCommand(MainMeterButtonMethod);
            BuildingInvoiceButtonCommand=new RelayCommand(BuildingInvoiceButtonMethod);
            InitDatabaseButtonCommand = new RelayCommand(InitDatabaseButtonMethod);
        }
    }
}