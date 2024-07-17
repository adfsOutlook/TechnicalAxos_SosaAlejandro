using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TechnicalAxos_SosaAlejandro.Model;
using TechnicalAxos_SosaAlejandro.Services;

namespace TechnicalAxos_SosaAlejandro.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _initialImageUrl;
        private string _currentImage;
        private ICommand _reloadCommand;
        private ObservableCollection<Country> _countries;
        private readonly ICountryService _countryService;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string InitialImageUrl
        {
            get { return _initialImageUrl; }
            set
            {
                _initialImageUrl = value;
                OnPropertyChanged();
            }
        }

        public string CurrentImage
        {
            get { return _currentImage; }
            set
            {
                _currentImage = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Country> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
                OnPropertyChanged();
            }
        }
        public ICommand ReloadCommand => _reloadCommand ??= new Command(ExecuteReloadCommand);

        public MainPageViewModel(ICountryService countryService)
        {
            _countryService = countryService;
            Title = "Test de Alejandro Sosa";
            InitialImageUrl = "https://random.dog/af70ad75-24af-4518-bf03-fec4a997004c.jpg";
            CurrentImage = InitialImageUrl; // Inicialmente muestra la imagen fija
            Countries = new ObservableCollection<Country>();
            LoadCountries();
        }

        public async Task LoadCountries()
        {
            var countries = await _countryService.GetCountriesAsync();
            foreach (var country in countries.Take(20))
            {
                Countries.Add(country);
            }
        }

        private async void ExecuteReloadCommand()
        {
            try
            {
                // Acceder a la galería del dispositivo para seleccionar una imagen
                var pickedFile = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Seleccione una imagen"
                });

                if (pickedFile != null)
                {
                    // Actualizar la imagen actual con la nueva imagen seleccionada
                    CurrentImage = pickedFile.FullPath;
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir al acceder a la galería
                Console.WriteLine($"Error al seleccionar una imagen: {ex.Message}");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
