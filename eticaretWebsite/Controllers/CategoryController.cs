using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eticaretWebsite.Controllers
{
    public class CategoryController : Controller
    {
        
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index() 
        {
            List<Category> categories= _categoryService.GetListAll();
            return View(categories);
        }
        public IActionResult GetirHepsi()
        {
            List<Category> categories = _categoryService.GetListAll();
            var JsonData = JsonConvert.SerializeObject(categories);
            return Json(JsonData);
        }
    }
}
