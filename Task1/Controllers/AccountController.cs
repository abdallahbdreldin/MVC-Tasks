using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Task1.Models;
using Task1.VeiwModels;

namespace Task1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
       {
            return View();
       }

        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> Register(RegisterUserViewModel registerFromRequest)
       {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = registerFromRequest.UserName;
                user.PasswordHash = registerFromRequest.Password;
                user.Address = registerFromRequest.Adderss;

                var result = await _userManager.CreateAsync(user,registerFromRequest.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user,false);
                    RedirectToAction("Index", "Instructor");
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("" , item.Description);
                }
            }
            return View("Register",registerFromRequest);
       }

        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginFromRequest)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(loginFromRequest.UserName);
                if (user!=null)
                {
                    bool found = await _userManager.CheckPasswordAsync(user, loginFromRequest.Password);

                    if(found)
                    {
                        //await _signInManager.SignInAsync(user, loginFromRequest.RememberMe);
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address",user.Address));

                        await _signInManager.SignInWithClaimsAsync(user,loginFromRequest.RememberMe, claims);
                        return RedirectToAction("Index", "Instructor");
                    }
                }
                ModelState.AddModelError("", "Invalid User");
            }
            return View("Login",loginFromRequest);
        }

        public IActionResult Welcome()
        {
            if (User.Identity.IsAuthenticated)
            {
                Claim? claimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string id = claimId.Value;
                Claim? AddClaim = User.Claims.FirstOrDefault(a => a.Type == "Address");
                string Address = AddClaim.Value;

                return Content($"Welcome {User.Identity.Name}");
            }
            return Content($"Welcome Guest");
        }

       public async Task<IActionResult> Logout()
       {
           await _signInManager.SignOutAsync();
           return RedirectToAction("Login");
       }
    }
}
