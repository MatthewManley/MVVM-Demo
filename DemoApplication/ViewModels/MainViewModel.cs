using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DemoApplication.Factories;
using DemoApplication.MVVM;
using DemoApplication.Properties;
using Domain;
using Domain.Repositories;
using log4net;
using ICommand = System.Windows.Input.ICommand;

namespace DemoApplication.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region " background variables "
        private VehicleViewModel _selectedVehicle;
        #endregion

        private readonly ILog _log;
        private readonly IVehicleService _vehicleService;
        private readonly VehicleViewModelFactory _vehicleFactory;

        public ObservableCollection<VehicleViewModel> Vehicles { get; }

        public ICommand AddVehicleCommand => new DelegateCommand<string>(AddVehicle);

        public VehicleViewModel SelectedVehicle
        {
            get { return _selectedVehicle; }
            set
            {
                if (Equals(value, _selectedVehicle)) return;
                _selectedVehicle = value;
                OnPropertyChanged();
            }
        }

        public BackgroundManager BackgroundManager { get; }

        public MainViewModel(ILog log, IVehicleService vehicleService, VehicleViewModelFactory vehicleFactory, BackgroundManager backgroundManager, ObservableCollection<VehicleViewModel> vehicles)
        {
            _log = log;
            _vehicleService = vehicleService;
            _vehicleFactory = vehicleFactory;

            BackgroundManager = backgroundManager;
            BackgroundManager.PropertyChanged += (s, e) => OnPropertyChanged(nameof(BackgroundManager));

            Vehicles = vehicles;

            _log.Info("MainViewModel initialised.");
        }

        public async Task Load()
        {
            try
            {
                WorkingViewModel.Instance.Working = true;

                var vehicles = (await _vehicleService.GetVehicles()).Select(vehicle => _vehicleFactory.Create(vehicle));

                //TODO: See about making this work
                //Vehicles = new ObservableCollection<VehicleViewModel>(vehicles);

                foreach (var vehicle in vehicles)
                    Vehicles.Add(vehicle);

                SelectedVehicle = Vehicles.First();

                _log.Info("MainViewModel loaded.");
            }
            finally
            {
                WorkingViewModel.Instance.Working = false;
            }
        }

        private void AddVehicle(string type)
        {
            SelectedVehicle = _vehicleFactory.Create(type);
        }

        #region " inpc "
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}