using Company.Data.Models;
using Company.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
    }
}
