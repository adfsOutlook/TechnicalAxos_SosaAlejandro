using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalAxos_SosaAlejandro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAxos_SosaAlejandro.Services;

namespace TechnicalAxos_SosaAlejandro.ViewModels.Tests
{
    [TestClass()]
    public class MainPageViewModelTests
    {
        [TestMethod()]
        public void LoadCountriesTest()
        {
            CountryService countryService = new CountryService();
            MainPageViewModel mainPageViewModel = new MainPageViewModel(countryService); // Instancia del servicio real o mock
          
            // Act
            mainPageViewModel.LoadCountries();

            // Assert
            Assert.IsNotNull(mainPageViewModel.Countries, "Countries collection no debe ser null.");
            Assert.IsTrue(mainPageViewModel.Countries.Count > 0, "Countries collection no debe estar vacio.");
            Assert.IsTrue(mainPageViewModel.Countries.All(c => c.name != null), "todos los = country deben tener un name.");

        }
    }
}