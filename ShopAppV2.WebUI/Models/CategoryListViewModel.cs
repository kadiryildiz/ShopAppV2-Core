using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopAppV2.Entities;

namespace ShopAppV2.WebUI.Models
{
    public class CategoryListViewModel
    {
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
