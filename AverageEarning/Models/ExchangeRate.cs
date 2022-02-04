namespace AverageEarning.Models
{
 
    public class ExchangeRate
    {
        public string Table { get; set; }
        public string No { get; set; }
        public string EffectiveDate { get; set; }
        public Rate[] Rates { get; set; }
    }

}


