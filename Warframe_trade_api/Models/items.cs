namespace Warframe_trade_api.Models
{
    public class PayloadItems
    {
        public items_ payload { get; set; }
    }
    public class items_
    {
        public List<item> items { get; set; } = new();
    }
    public class item
    {
        public string id { get; set; }
        public string url_name { get; set; }
        public string item_name { get; set; }
    }
}
