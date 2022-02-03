namespace AverageEarning.Models
{
    public class DailyRate
    {
        public float Rate { get; set; }
        public Code Code { get; set; }
    }
    public enum Code
    {
        PLN,
        USD,
        Euro
    }
}
