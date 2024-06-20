using Microsoft.EntityFrameworkCore;
using BitcoinPriceFetcher.Models;

namespace BitcoinPriceFetcher.Data
{
    public class BitcoinPriceContext : DbContext
    {
        public DbSet<BitcoinPrice> BitcoinPrices { get; set; }

        public BitcoinPriceContext(DbContextOptions<BitcoinPriceContext> options) : base(options)
        {
        }
    }
}
