using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechnicalAxos_SosaAlejandro.Model;

namespace TechnicalAxos_SosaAlejandro.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetCountriesAsync();
    }

    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Country>> GetCountriesAsync()
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var countries = JsonSerializer.Deserialize<List<Country>>(json);
                return countries;
            }
            else
            {
                // Handle error if API call fails
                return new List<Country>();
            }
        }
    }
}
