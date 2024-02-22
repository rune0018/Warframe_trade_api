namespace Warframe_trade_api.Models
{
    public interface IOrderDTO
    {
        public string order_type { get; set; }
        public User user { get; set; }
        public int platinum { get; set; }
        public int CompareTo(Order obj) { return platinum.CompareTo(obj.platinum); }
    }
}
