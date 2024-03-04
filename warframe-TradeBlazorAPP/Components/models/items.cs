namespace warframe_TradeBlazorAPP.Components.models
{
    public class PayloadItems
    {
        public Items_ payload { get; set; }
    }
    public class Items_
    {
        public List<Item> items { get; set; } = new();
    }
    public class Item
    {
        public string id { get; set; }
        public string url_name { get; set; }
        public string item_name { get; set; }
    }
}
