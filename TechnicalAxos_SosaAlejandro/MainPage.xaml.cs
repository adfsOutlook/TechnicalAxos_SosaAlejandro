
using TechnicalAxos_SosaAlejandro.Services;
using TechnicalAxos_SosaAlejandro.ViewModels;
namespace TechnicalAxos_SosaAlejandro
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            var countryService = new CountryService();
            BindingContext = new MainPageViewModel(countryService);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Establecer la imagen inicial desde la URL específica
            if (BindingContext is MainPageViewModel viewModel)
            {
                viewModel.CurrentImage = viewModel.InitialImageUrl;
            }
        }
    }

}
