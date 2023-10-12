namespace GameStart.Core.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public decimal UnitPrice { get; private set; }
        public int Units { get; private set; }

        private OrderItem()
        {

        }

        public OrderItem(decimal unitPrice, int units)
        {
            UnitPrice = unitPrice;
            Units = units;
        }
    }
}
