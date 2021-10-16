using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppV2.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public List<CartItem> CartItems { get; set; }  // cart içerisinde bulunan tüm cartItemler'ı alabilmek için.     Cart.CartItems 
    }
}
