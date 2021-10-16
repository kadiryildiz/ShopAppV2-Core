using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppV2.Business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId);
    }
}
