using LoginModule.Models;
using LoginModule.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginModule.Controllers
{
    public class AccountController : Controller
    {
        private readonly SupabaseService _supabase;

        public AccountController(SupabaseService supabase)
        {
            _supabase = supabase;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _supabase.Login(model.Email, model.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("Role", user.Role);
                HttpContext.Session.SetString("Name", user.Fullname);
                HttpContext.Session.SetInt32("UserId", user.Id);


                if (user.Role == "admin")
                {
                    return RedirectToAction("AdminDashboard");
                }

                if (user.Role == "staff")
                {
                    return RedirectToAction("StaffDashboard");
                }

                return RedirectToAction("UserDashboard");
            }

            ViewBag.Error = "Invalid Email or Password";

            return View(model);
        }

        //debugger
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    var user = await _supabase.Login(model.Email, model.Password);

        //    if (user == null)
        //    {
        //        return Content("NO USERS FOUND");
        //    }

        //    return Content(
        //        "FOUND USER: " +
        //        user.Email +
        //        " | PASSWORD: " +
        //        user.Password +
        //        " | NAME: " +
        //        user.Fullname
        //    );
        //}


        //debugger
        /*
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            return Content("FORM SUBMITTED");
        }
        */

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AdminDashboard()
        {
            if (HttpContext.Session.GetString("Role") != "admin")
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult StaffDashboard()
        {
            if (HttpContext.Session.GetString("Role") != "staff")
            {
                return RedirectToAction("Login");
            }

            return View();
        }


        //userRegister
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new UserModel
            {
                Fullname = model.Fullname,
                Email = model.Email,
                Password = model.Password,
                Role = "user"
            };

            await _supabase.Client
                .From<UserModel>()
                .Insert(user);

            return RedirectToAction("Login");
        }


        //userdashboard
        public IActionResult UserDashboard()
        {
            if (HttpContext.Session.GetString("Role") != "user")
            {
                return RedirectToAction("Login");
            }

            return View();
        }


    }
}