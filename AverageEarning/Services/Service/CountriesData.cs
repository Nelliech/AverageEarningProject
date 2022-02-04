using AverageEarning.Models;
using AverageEarning.Services.Interface;

namespace AverageEarning.Services.Service
{
    public class CountriesData : ICountriesData
    {
        public ICollection<Country> GetAllCountries()
        {
            ICollection<Country> Countries = new List<Country>() {
            new Country() { Name="UK", Code = "GBP", Tax = 25, FixedCost = 600 },
            new Country() { Name="DE", Code = "EUR", Tax = 20, FixedCost = 800 },
            new Country() { Name="PL", Code = "PLN", Tax = 19, FixedCost = 1200 }
            };

            return Countries;
        }
    }
}
