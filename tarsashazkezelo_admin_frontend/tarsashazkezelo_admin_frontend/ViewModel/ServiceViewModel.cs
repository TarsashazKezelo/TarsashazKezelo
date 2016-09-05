using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.ViewModel
{
    public class ServiceViewModel : ViewModelBase
    {
        public ObservableCollection<Service> Services { get; }

        private Service _editedService;

        public Service EditedService
        {
            get { return _editedService; }
            set
            {
                Set(ref _editedService, value);
            }
        }

        private MainMeter _selectedMainMeter;

        public MainMeter SelectedMainMeter
        {
            get { return _selectedMainMeter; }
            set { Set(ref _selectedMainMeter, value); }
        }

        public ICommand AddServiceCommand { get; private set; }

        public void AddServiceMethod()
        {
            EditedService=new Service() { ID = Services.Count() + 1, Name = "" };
        }

        public ICommand SaveServiceCommand { get; private set; }

        public void SaveServiceMethod()
        {
            Services.Add(EditedService);
            EditedService = null;

        }

        public ServiceViewModel()
        {
            AddServiceCommand = new RelayCommand(AddServiceMethod);
            SaveServiceCommand=new RelayCommand(SaveServiceMethod);
            Services = new ObservableCollection<Service>();
        }
    }
}
