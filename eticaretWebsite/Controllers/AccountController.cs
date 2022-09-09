using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using eticaretWebsite.Dtos;
using eticaretWebsite.Extentsions;
using eticaretWebsite.Identity;
using eticaretWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eticaretWebsite.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;
        private IBrandService _brandService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IBrandService brandService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _brandService = brandService;
            _roleManager = roleManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? ReturnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "bu Kullanıcı Emaili ile daha önce hesap oluşturulmamıştır !");
                return View(model);
            }
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", " Lütfen email hesabınza gelen link ile üyeliğinizi onaylayınız. ");
                return View(model);
            }
            else
            {

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

                if (result.Succeeded)
                {
                    return Redirect(model.ReturnUrl ?? "~/");
                }
                ModelState.AddModelError("", "Girilen Kullanıcı Adı Veya Parola Yanlıştır !");
            }


            return View(model);
        }
        public IActionResult BrandRegister()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BrandRegister(BrandRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new User();
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.EmailConfirmed = true;
            //user.Brand = new Brand(model.BrandName);

            var role = "Admin";

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
                await _userManager.AddToRoleAsync(user, role);
                TempData.Put("message", new AlertMessage()
                {
                    Message = "Hesabınız başarıyla oluşturuldu",
                    AlertType = "success"
                });
                return RedirectToAction(nameof(Login));
            }
            else
            {
                result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
            }
            return View();
        }
        public IActionResult CustomerRegister()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerRegister(CustomerRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.UserName,
                EmailConfirmed = true
            };

            var role = "Customer";

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
                await _userManager.AddToRoleAsync(user, role);
                TempData.Put("message", new AlertMessage()
                {
                    Message = "Hesabınız başarıyla oluşturuldu",
                    AlertType = "success"
                });
                return RedirectToAction(nameof(Login));
            }
            else
            {
                result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData.Put("message", new AlertMessage()
            {
                Message = "Hesabınız Güvenli Bir şekilde Kapatıldı.",
                AlertType = "success"
            });
            return Redirect("/");
        }

    }
}
