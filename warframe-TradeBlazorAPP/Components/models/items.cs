namespace warframe_TradeBlazorAPP.Components.models
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
