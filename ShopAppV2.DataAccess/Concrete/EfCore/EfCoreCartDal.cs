using System;
using System.Collections.Generic;
using System.Text;
using ShopAppV2.DataAccess.Abstract;
using ShopAppV2.Entities;

namespace ShopAppV2.DataAccess.Concrete.EfCore
{
    public class EfCoreCartDal : EfCoreGenericRepository<Cart, ShopContext>, ICartDal
    {
    }
}
