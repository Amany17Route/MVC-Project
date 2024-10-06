using Company.Data.Models;
using Company.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
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

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Signup(SignUpViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = input.Email.Split("@")[0],
                    Email = input.Email,
                    FirastName=input.FirstName,
                    LastName=input.LasttName,
                    IsActive=true

                };

                var result =await _userManager.CreateAsync(user ,input.Password);

                if (result.Succeeded) {

                    return RedirectToAction("SignIn");
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("" ,err.Description);
                }
            }
            return View(input);
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid) { 
                var user = await _userManager.FindByEmailAsync(model.Email);

                if ( user is not null)
                {
                    if (await _userManager.CheckPasswordAsync(user , model.Password)) 
                    { 
                    var result= await _signInManager.PasswordSignInAsync(user , model.Password, model.RememberMe ,false );
                        if (result.Succeeded) 
                        {
                            return RedirectToAction("Index", "Home");
                        
                        }
                    
                    }
                        
                }
                ModelState.AddModelError("", "Invalid Login");
                return View(model);
            }


            return View(model);
        }


        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(SignIn));
        }
    }
}
