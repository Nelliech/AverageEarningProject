using AverageEarning.Models;

namespace AverageEarning.Services.Interface
{
    public interface IExchange
    {
        List<Payout> ExchangeToPLN(float rate, string code, List<ExchangeRate> exchangeRates, ICollection<Country> countries);

    }
}
