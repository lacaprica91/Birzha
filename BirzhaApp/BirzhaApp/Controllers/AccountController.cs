using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirzhaApp.Models;
using BirzhaApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BirzhaApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private RoleManager<IdentityRole> roleManager;
        private IUserValidator<User> userValidator;
        private IPasswordValidator<User> passwordValidator;
        private IPasswordHasher<User> passwordHasher;
        private IExperienceRepository expRepo;
        private IEducationRepository eduRepo;
        private IVolunteeringRepository voluntRepo;

        public AccountController(UserManager<User> userMgr, SignInManager<User> signInMgr,
                            IUserValidator<User> userValid,
                            IPasswordValidator<User> passValid,
                            IPasswordHasher<User> passwordHash,
                            RoleManager<IdentityRole> roleMgr, IExperienceRepository exRepo, IEducationRepository edRepo, IVolunteeringRepository volRepo)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            roleManager = roleMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
            expRepo = exRepo;
            eduRepo = edRepo;
            voluntRepo = volRepo;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl});
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(loginModel.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel.ReturnUrl ?? "/Home/Home");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        public IActionResult MyProfile()
        {
            return View();
        }


        //CRUD OF USER ACCOUNTS AND PROFILE
        //----------------------------------------------------------------------------
        public ViewResult MngUsers() => View(userManager.Users);

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateUser model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View("~/Views/Home/Index.cshtml", model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User userModel)
        {
            User user = await userManager.FindByIdAsync(userModel.Id);
            if (user != null)
            {
                //user.Email = userModel.Email;
                //IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);
                //if (!validEmail.Succeeded)
                //{
                //    AddErrorsFromResult(validEmail);
                //}
                //else
                //{
                //    user.UserName = userModel.Email;
                //}
                //IdentityResult validPass = null;
                //if (!string.IsNullOrEmpty(password))
                //{
                //    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                //    if (validPass.Succeeded)
                //    {
                //        user.PasswordHash = passwordHasher.HashPassword(user, password);
                //    }
                //    else
                //    {
                //        AddErrorsFromResult(validPass);
                //    }
                //}
                //if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded
                //        && password != string.Empty && validPass.Succeeded))
                //{
                //    IdentityResult result = await userManager.UpdateAsync(user);
                //    if (result.Succeeded)
                //    {
                //        return RedirectToAction("Index");
                //    }
                //    else
                //    {
                //        AddErrorsFromResult(result);
                //    }
                //}
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View(user);
        }

        //EXPERINCE CRUD
        [HttpPost]
        public ActionResult EditExperience(Experience expModel)
        {
            return View(expModel);
        }

        //EDUCATION CRUD
        [HttpPost]
        public ActionResult EditEducation(Education eduModel)
        {
            return View(eduModel);
        }

        //VOLUNTEERING CRUD
        [HttpPost]
        public ActionResult EditVolunteering(Volunteering volModel)
        {
            return View(volModel);
        }


        //[HttpPost]
        //[Authorize(Roles = "SysAdmin")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    User user = await userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //        IdentityResult result = await userManager.DeleteAsync(user);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            AddErrorsFromResult(result);
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "User Not Found");
        //    }
        //    return View("Index", userManager.Users);
        //}

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }




        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}