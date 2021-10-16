using System;
using System.Collections.Generic;
using System.Text;
using ShopAppV2.Business.Abstract;
using ShopAppV2.DataAccess.Abstract;
using ShopAppV2.Entities;

namespace ShopAppV2.Business.Concrete
{
    public class CartManager:ICartService
    {
        private ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }
        public void InitializeCart(string userId)
        {
            _cartDal.Create(new Cart() { UserId = userId });
        }
    }
}
