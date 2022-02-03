using AverageEarning.Models;
using AverageEarning.Services.Interface;

namespace AverageEarning.Services.Service
{
    public class Exchange : IExchange
    {
        protected Payout newPayout { get; set; }
        float dayOfMouth = 22;
        List<Payout> payouts { get; set; }
        
        public float ExchangeToPLN(float rate, string code, List<ExchangeRate> exchangeRates, ICollection<Country> countries)
        {
            foreach (var country in countries)
            {
                newPayout.CountryName = country.Name;
                if(country.Code == code)
                {
                    newPayout.Rate = ((rate * dayOfMouth) - (rate * country.Tax / 100))-country.FixedCost;
                }
                else
                {

                }
                
            }
            return 0;
        }
    }
}
