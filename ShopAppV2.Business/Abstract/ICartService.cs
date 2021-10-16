using System;
using System.Collections.Generic;
using System.Text;
using ShopAppV2.Entities;

namespace ShopAppV2.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId);
        Cart GetCartByUserId(string userId);
        void AddToCart(string userId, int productId, int quantity);
    }
}
