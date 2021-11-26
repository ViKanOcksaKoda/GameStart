﻿namespace GameStart.Endpoints.ShoppingCarts
{
    public class GetByIdShoppingCartsRequest : BaseRequest
    {
        public string UserId { get; set; }
        public int ShoppingCartId { get; set; }
    }
}