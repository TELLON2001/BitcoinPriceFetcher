namespace BitcoinPriceFetcher.Models
{
    public class BitcoinPrice
    {
        public int id { get; set; }
        public string source { get; set; }
        public decimal price { get; set; }
        public DateTime timestamp { get; set; }
    }
}
