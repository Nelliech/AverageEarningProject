using AverageEarning.Models;
using AverageEarning.Services.Interface;
using System.Globalization;

namespace AverageEarning.Services.Service
{
    public class Exchange : IExchange
    {
        protected List<Payout> payouts=new List<Payout>();
        protected Payout newPayout { get; set; }

        protected float dayOfMouth = 22;
        protected float currencyRatePresent = 1;
        protected float currencyRatePresentByGivenCode = 1;
        float rateWithoutTax = 0;
        public List<Payout> ExchangeToPLN(float rate, string code, List<ExchangeRate> exchangeRates, ICollection<Country> countries)
        {
            var ListRate = exchangeRates.FirstOrDefault();
            foreach (var country in countries)
            {
                newPayout = new Payout();
                if (country.Code != "PLN")
                {
                    currencyRatePresent = ListRate.Rates.FirstOrDefault(p => p.Code == country.Code).Mid;
                }
                newPayout.CountryName = country.Name;
                if (code == "PLN")
                {
                    if(country.Code != "PLN")
                    {
                        rateWithoutTax = (rate * dayOfMouth)- (country.FixedCost * currencyRatePresent);
                        newPayout.Rate= rateWithoutTax - (rateWithoutTax * country.Tax / 100);
                    }
                    else
                    {
                        rateWithoutTax=((rate * dayOfMouth) -country.FixedCost);
                        newPayout.Rate = rateWithoutTax - (rateWithoutTax * country.Tax / 100);
                    }
                }
                else
                {
                    currencyRatePresentByGivenCode = ListRate.Rates.FirstOrDefault(p => p.Code ==code).Mid;

                    rateWithoutTax = ((rate*dayOfMouth)* currencyRatePresentByGivenCode)-(country.FixedCost*currencyRatePresent);
                    newPayout.Rate = rateWithoutTax - (rateWithoutTax * country.Tax / 100);
                }

                //if(country.Code == code)
                //{

                //    newPayout.Rate = ((rate * dayOfMouth) - (rate * country.Tax / 100))-country.FixedCost;

                //}
                //else
                //{
                //    newPayout.Rate = (((rate*dayOfMouth)-(rate*country.Tax/100))-country.FixedCost)*currencyRatePresent;
                //}

              

                newPayout.Code = "PLN";
                payouts.Add(newPayout);
            }
            return payouts;
        }
    }
}
