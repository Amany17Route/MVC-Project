using Company.Data.Models;
using Company.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Company.Web.Controllers
{
    public class RollesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RollesController> _logger;


        public RollesController(
        RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager,
        ILogger<RollesController> logger
        )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;

        }


        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }


        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {

            if (ModelState.IsValid)
            {
                var role = new IdentityRole
                {
                    Name = roleViewModel.Name
                };
                var res = await _roleManager.CreateAsync(role);

                if (res.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var i in res.Errors)
                {
                    _logger.LogInformation(i.Description);


                }

            }
            return View(roleViewModel);

        }




        public async Task<IActionResult> Details(string? id, string viewname = "Details")
        {

            var role = await _roleManager.FindByIdAsync(id);

            if (role is null)
            {
                return NotFound();
            }
            var roleViewModel = new RoleViewModel
            {

                Id = role.Id,
                Name = role.Name
            };

            return View(viewname, roleViewModel);
        }


        [HttpGet]

        public async Task<IActionResult> Update(string? id)
        {
            return await Details(id, "Update");
        }

        [HttpPost]

        public async Task<IActionResult> Update(string? id, RoleViewModel roleViewModel)
        {

            if (id != roleViewModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(id);
                    if (role is null)
                    {
                        return NotFound();
                    }
                    role.Name = roleViewModel.Name;
                    role.NormalizedName = roleViewModel.Name.ToUpper();

                    var res = await _roleManager.UpdateAsync(role);

                    if (res.Succeeded)
                    {
                        _logger.LogInformation("User Updated Successfully");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _logger.LogInformation("User Updated Faild");
                        return View(roleViewModel);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
            }
            return View(roleViewModel);

        }


        public async Task<IActionResult> Delete(string id)
        {
            try
            {

                var role = await _roleManager.FindByIdAsync(id);

                if (role is null)
                {
                    return NotFound();
                }
                var res = await _roleManager.DeleteAsync(role);

                if (res.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var i in res.Errors)
                {
                    _logger.LogError(i.Description);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return RedirectToAction(nameof(Index));


        }
    }
}