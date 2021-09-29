using System;
using System.Collections.Generic;
using System.Text;
using ShopAppV2.Entities;

namespace ShopAppV2.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
    }
}
