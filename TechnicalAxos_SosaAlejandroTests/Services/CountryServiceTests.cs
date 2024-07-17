using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalAxos_SosaAlejandro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAxos_SosaAlejandro.Services.Tests
{
    [TestClass()]
    public class CountryServiceTests
    {
        [TestMethod()]
        public async void GetCountriesAsyncTest()
        {
            // Arrange
            CountryService countryService = new CountryService(); // Instancia del servicio real o mock

            // Act
            List<Model.Country> countries = await countryService.GetCountriesAsync();

            // Assert
            Assert.IsNotNull(countries, "La coleccion de Countries no deberia ser null.");
            Assert.IsTrue(countries.Count > 0, "La coleccion de Countries no deberia estar vacia.");

        }
    }
}