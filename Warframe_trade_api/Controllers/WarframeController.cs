using Microsoft.AspNetCore.Mvc;
using Warframe_trade_api.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Warframe_trade_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarframeController : ControllerBase
    {
        public static Dictionary<string, int> cache = new Dictionary<string, int>();
        public static DateTime timestamp { get; set; }
        // GET: api/<WarframeController>
        [HttpGet]
        public async Task<List<item>> Get()
        {
            var list = new List<item>();
            using (HttpClient client = new())
            {
                HttpResponseMessage message = await client.GetAsync("https://api.warframe.market/v1/items");
                message.EnsureSuccessStatusCode();
                PayloadItems ite = await message.Content.ReadFromJsonAsync<PayloadItems>();
                list = ite.payload.items;
            }
            foreach (var item in list)
            {
                if(!cache.ContainsKey(item.url_name))
                    cache.Add(item.url_name, 0);
            }
            return list;
        }

        // GET api/<WarframeController>/5
        [HttpGet("{url_name}/orders")]
        public async Task<int> Get(string url_name)
        {
            int averagePrice;
            if(cache.ContainsKey(url_name))
            if (cache[url_name] != 0)
            {
                    return cache[url_name];
            }
            List<Order> orders = new List<Order>();
            using (HttpClient client = new())
            {
                HttpResponseMessage message = await client.GetAsync($"https://api.warframe.market/v1/items/{url_name}/orders");
                message.EnsureSuccessStatusCode();
                PayloadOrders orede = await message.Content.ReadFromJsonAsync<PayloadOrders>();
                orders = orede.payload.orders;
            }
            orders = orders.Where(o => o.order_type == "sell").ToList();
            orders.Sort();
            averagePrice = 0;
            for(int i = 5; i > 0; i--)
            {
                averagePrice += orders[i].platinum;
            }
            if (cache.ContainsKey(url_name))
                cache[url_name] = averagePrice / 5;
            return averagePrice / 5;
        }
    }
}
