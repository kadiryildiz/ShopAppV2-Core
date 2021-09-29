using System;
using System.Collections.Generic;
using System.Text;
using ShopAppV2.Entities;

namespace ShopAppV2.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        Product GetProductDetails(int id);
        List<Product> GetAll();
        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
    }
}
