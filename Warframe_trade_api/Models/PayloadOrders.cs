namespace Warframe_trade_api.Models
{
    public class PayloadOrders
    {
        public Orders payload { get; set; }
    }
    public class Orders
    {
        public List<Order> orders { get; set; } = new();
    }
    public class Order : IComparable<Order>,IOrderDTO
    {
        public string platform { get; set; }
        public string order_type { get; set; }
        public bool visible { get; set; }
        public DateTime creation_date { get; set; }
        public int quantity { get; set; }
        public User user { get; set; }
        public DateTime last_update { get; set; }
        public int platinum { get; set; }
        public string id { get; set; }
        public string region { get; set; }

        public int CompareTo(Order obj)
        {
            return platinum.CompareTo(obj.platinum);
        }
    }
    public class User
    {
        public int reputation { get; set; }
        public string locale { get; set; }
        public object avatar { get; set; }
        public string ingame_name { get; set; }
        public DateTime last_seen { get; set; }
        public string id { get; set; }
        public string region { get; set; }
        public string status { get; set; }
    }
}
