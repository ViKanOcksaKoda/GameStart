using GameStart.Core.Entities;

namespace GameStart.Endpoints.Orders
{
    public class ListOrderResponse : BaseResponse
    {
        public ListOrderResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListOrderResponse()
        {
        }

        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}