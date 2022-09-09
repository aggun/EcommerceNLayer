using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using eticaretWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace eticaretWebsite.Controllers
{
    public class HomeController : Controller
    {
       
        private IProductService _productService;
        private IBrandService _brandService;
        public HomeController(IProductService productService, IBrandService brandService)
        {
            _productService = productService;
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            List<Product> products = _productService.GetProductFeatures();
            
            return View(products);
        }
        public IActionResult ProductDetails(int id)
        {
            if (id == null) { return NotFound(); }
            Product product= _productService.GetByID(id);
            
            return View(product);
        }
        public IActionResult MarkalarGetir()
        {
            List<Brand> brands = _brandService.GetListAll();
            var JsonData = JsonConvert.SerializeObject(brands);
            return Json(JsonData);
        }

    }
}