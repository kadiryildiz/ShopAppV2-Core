using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopAppV2.Business.Abstract;
using ShopAppV2.WebUI.Models;

namespace ShopAppV2.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(new ShopAppV2.WebUI.Models.ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }
    }
}