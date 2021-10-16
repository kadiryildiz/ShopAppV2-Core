using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppV2.Entities
{
    public class CartItem
    {
        public int Id { get; set; }

        public Product Product { get; set; }  //product tablosuna direk erişim için..
        public int ProductId { get; set; }  //kullanıcı hangi ürünü ekledi ?

        public Cart Cart { get; set; }
        public int CartId { get; set; }     //kullanıcı hangi kartı eklemiş ?  cart.id = cartItem.CartId

        public int Quantity { get; set; }
    }
}
