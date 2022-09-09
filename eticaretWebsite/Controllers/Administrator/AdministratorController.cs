using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using eticaretWebsite.Data;
using eticaretWebsite.Dtos;
using eticaretWebsite.Extentsions;
using eticaretWebsite.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eticaretWebsite.Controllers.Administrator
{
    [Authorize]
    public class AdministratorController : Controller
    {
        private IProductService _productService;
        private IFeatureService _featureService;
        private ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _db;
        public AdministratorController(ApplicationDbContext db, IProductService productService, IFeatureService featureService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _productService = productService;
            _featureService = featureService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }
        private User user() { return _db.Users.Where(x => x.UserName == User.Identity.Name).SingleOrDefault(); }
        public IActionResult CreateProduct()
        {
            ViewBag.FeaturList = _featureService.GetListAll().Where(x=>x.BrandId== user().BrandId).ToList();
            ViewBag.CategoryList = _categoryService.GetListAll();
            ViewBag.BrandId = user().BrandId;
            return View(new Product());
        }
        [HttpPost]
        public IActionResult CreateProduct(Product model,List<int> FeaturIds,List<int> CategoriesId)
        {
            ViewBag.FeaturList = _featureService.GetListAll().Where(x => x.BrandId == user().BrandId).ToList();
            ViewBag.CategoryList = _categoryService.GetListAll();

            if (model == null && CategoriesId.Count() == 0)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Message = "model or CategoriesId is Null!  ",
                    AlertType = "danger"
                });
                return View(model);
            }

            string ImagePath = "";
            IFormFileCollection files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string ImageName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(files[0].FileName);

                FileStream fileStream = new FileStream(Path.Combine(webRootPath, "Product-img", ImageName), FileMode.Create);
                files[0].CopyTo(fileStream);

                ImagePath = @"\Product-img\" + ImageName;
            }
            Product product = new Product();
            product = model;
            product.ImageUrl = ImagePath;
            foreach (int item in CategoriesId)
            {
               // product.ProductCategorList.Add(new ProductCategory(item));
            }
            foreach (int item in FeaturIds)
            {
              //  product.ProductFeatureList.Add(new ProductFeature(item));
            }
            _productService.Insert(product);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult FeatureList()
        {
            List<Feature> features = _featureService.GetListAll().Where(x => x.BrandId == user().BrandId).ToList();
            return View(features);
        }
        public IActionResult ApplyDiscount(int id, int discount, string isDiscount)
        {
            Feature ff = _featureService.GetByID(id);
            if (isDiscount=="on")
            {
                ff.IsDiscounted = true;
                ff.DicountRate = discount;
            }
            if (isDiscount == null)
            {
                ff.IsDiscounted = false;
               // ff.DicountRate = null;
            }
            _featureService.Update(ff);
            return RedirectToAction(nameof(FeatureList));
        }

        public IActionResult CreateFeature()
        {
            ViewBag.BrandId = user().BrandId;
            return View(new Feature());
        }
        [HttpPost]
        public IActionResult CreateFeature(Feature model)
        {
            Feature feature  = new Feature();
            feature = model;
            //feature.FeatureName = model.FeatureName;
            //feature.FeatureValu = model.FeatureValu;
            //feature.BrandId = model.BrandId;
            //feature.DicountRate = model.DicountRate;

            _featureService.Insert(feature);

            return RedirectToAction(nameof(Index));
        }
    }
}
