using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
        private ObservableCollection<Service> _services;

        public ObservableCollection<Service> Services
        {
            get { return _services; }
        }

        private Service _selectedService;

        public Service SelectedService
        {
            get { return _selectedService; }
            set
            {
                Set(ref _selectedService, value);
                EditedService = new Service { ID = value.ID, MainMeter = value.MainMeter, Name = value.Name };
            }
        }

        private Service _editedService;

        public Service EditedService
        {
            get { return _editedService; }
            set { Set(ref _editedService, value); }
        }

        private bool _visibility;

        public bool Visibility
        {
            get { return _visibility; }
            set { Set(ref _visibility, value); }
        }

        public ICommand ServiceButtonCommand { get; private set; }

        public void ServiceButtonMethod()
        {
            Visibility = true;
        }

        public ICommand AddServiceCommand { get; private set; }

        public void AddServiceMethod()
        {
            Services.Add(new Service { ID = 0, MainMeter = new MainMeter { ID = 0, Reading = 0 }, Name = "Szolgáltatás" });
            SelectedService = Services.Last();
        }

        public ICommand RemoveServiceCommand { get; private set; }

        public void RemoveServiceMethod()
        {
            Services.Remove(SelectedService);
            EditedService = null;
        }

        public ICommand SaveServiceCommand { get; private set; }

        public void SaveServiceMethod()
        {
            SelectedService.ID = EditedService.ID;
            SelectedService.Name = EditedService.Name;
            SelectedService.MainMeter.Reading = EditedService.MainMeter.Reading;
        }



        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ServiceButtonCommand = new RelayCommand(ServiceButtonMethod);
            AddServiceCommand = new RelayCommand(AddServiceMethod);
            RemoveServiceCommand = new RelayCommand(RemoveServiceMethod);
            SaveServiceCommand = new RelayCommand(SaveServiceMethod);
            _services = new ObservableCollection<Service>();
        }
    }
}