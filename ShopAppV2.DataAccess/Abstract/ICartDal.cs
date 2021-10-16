using System;
using System.Collections.Generic;
using System.Text;
using ShopAppV2.Entities;

namespace ShopAppV2.DataAccess.Abstract
{
    public interface ICartDal : IRepository<Cart>
    {
        Cart GetByUserId(string userId);
    }
}
