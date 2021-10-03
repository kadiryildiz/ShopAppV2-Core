﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ShopAppV2.Entities;

namespace ShopAppV2.DataAccess.Abstract
{
    public interface IProductDal:IRepository<Product>
    {

        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        Product GetProductDetails(int id);
        int GetCountByCategory(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
    }
}
