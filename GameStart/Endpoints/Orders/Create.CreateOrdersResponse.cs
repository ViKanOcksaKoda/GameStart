namespace GameStart.Endpoints.Orders
{
    public class CreateOrdersResponse : BaseResponse
    {
        public CreateOrdersResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateOrdersResponse()
        {
        }
        public OrderDTO order { get; set; }
    }
}