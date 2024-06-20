using BitcoinPriceFetcher.Data;
using BitcoinPriceFetcher.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BitcoinPriceFetcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BitcoinPriceController : ControllerBase
    {
        private readonly BitcoinPriceContext _context;
        private static readonly HttpClient client = new HttpClient();

        public BitcoinPriceController(BitcoinPriceContext context)
        {
            _context = context;
        }

        [HttpGet("sources")]
        public IActionResult GetSources()
        {
            var sources = new List<string> { "Bitstamp", "Bitfinex" };
            return Ok(sources);
        }

        [HttpGet("fetch/{source}")]
        public async Task<IActionResult> FetchPrice(string source)
        {
            decimal price = 0;
            switch (source.ToLower())
            {
                case "bitstamp":
                    price = await FetchFromBitstamp();
                    break;
                case "bitfinex":
                    price = await FetchFromBitfinex();
                    break;
                default:
                    return BadRequest("Unknown source");
            }

            var bitcoinPrice = new BitcoinPrice
            {
                source = source,
                price = price,
                timestamp = DateTime.UtcNow
            };

            _context.BitcoinPrices.Add(bitcoinPrice);
            await _context.SaveChangesAsync();

            return Ok(bitcoinPrice);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var prices = await _context.BitcoinPrices.ToListAsync();
            return Ok(prices);
        }

        private async Task<decimal> FetchFromBitstamp()
        {
            var response = await client.GetStringAsync("https://www.bitstamp.net/api/v2/ticker/btcusd/");
            var jsonDoc = JsonDocument.Parse(response);
            var priceString = jsonDoc.RootElement.GetProperty("last").GetString();
            return decimal.Parse(priceString);
        }

        private async Task<decimal> FetchFromBitfinex()
        {
            var response = await client.GetStringAsync("https://api.bitfinex.com/v1/pubticker/btcusd");
            var jsonDoc = JsonDocument.Parse(response);
            var priceString = jsonDoc.RootElement.GetProperty("last_price").GetString();
            return decimal.Parse(priceString);
        }
    }
}
