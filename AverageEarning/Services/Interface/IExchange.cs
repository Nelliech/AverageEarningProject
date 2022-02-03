using AverageEarning.Models;

namespace AverageEarning.Services.Interface
{
    public interface IExchange
    {
        float ExchangeToPLN(float rate, string code, List<ExchangeRate> exchangeRates, ICollection<Country> countries);

    }
}
