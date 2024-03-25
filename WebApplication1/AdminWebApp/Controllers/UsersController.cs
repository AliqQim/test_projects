using aliksoft.AdminWebApp.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aliksoft.AdminWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<MyIdentityUser> _userManager;

        public UsersController(UserManager<MyIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var userViewModels = new List<UserItemViewModel>();

            foreach (var user in users)
            {
                var userViewModel = new UserItemViewModel
                {
                    Id = user.Id,
                    Email = user.Email!, //TODO check nullability
                    Roles = await _userManager.GetRolesAsync(user)
                };
                userViewModels.Add(userViewModel);
            }

            return View(userViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateUserViewModel());
        }

        //TODO make full CRUD

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); //displaying errors
            }

            var user = new MyIdentityUser { UserName = model.Email, Email = model.Email };

            //TODO make something transaction-like

            var result = await _userManager.CreateAsync(user, model.Password);
            
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            if (model.Role is "Admin" or "SuperAdmin")
            {
                await _userManager.AddToRoleAsync(user, Roles.Admin);
            }

            if (model.Role is "SuperAdmin")
            {
                await _userManager.AddToRoleAsync(user, Roles.SuperAdmin);
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                throw new Exception("Error deleting user " +  id);  //TODO bind this situation to interface (it it's ever possible)
            }
        }
    }
}
