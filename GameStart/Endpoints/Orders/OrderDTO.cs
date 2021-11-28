using GameStart.Core.Entities.OrderAggregate;

namespace GameStart.Endpoints.Orders
{
    public class OrderDTO
    {
        public string UserId { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTimeOffset date { get; set; }
        public List<OrderItem> OrderItem { get; set; }
    }
}
