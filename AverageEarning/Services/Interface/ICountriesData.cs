using AverageEarning.Models;

namespace AverageEarning.Services.Interface
{
    public interface ICountriesData
    {
        ICollection<Country> GetAllCountries();

    }
}
