using Blog.Database;
using Blog.Models.EntityModels;
using Blog.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TestBlog.Models;

namespace TestBlog.Controllers
{
    public class UserController : Controller
    {
        UserRepository context;

        private Users hasUser;

        public UserController()
        {
            context = new UserRepository();
        
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(UserCreate model)
        {

            if (ModelState.IsValid)
            {
                hasUser = context.GetByEmail(model.email);

                if (hasUser == null)
                {
                    var user = new Users()
                    {
                        firstName = model.firstName,
                        lastName = model.lastName,
                        email = model.email,
                        username = model.username,
                        password = model.password
                    };

                    bool _isSuccess = context.Add(user);

                    if (_isSuccess)
                    {
                        return RedirectToAction("Login", "User");
                    }
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        public IActionResult Login(UserLogin model)
        { 
            if (ModelState.IsValid)
            {               
                hasUser = context.GetByEmailAndPass(model.email, model.password);

                if (hasUser != null)
                {
                    //Set cookie
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Append("u_id", hasUser.Id.ToString(), option);

                    //Set session
                    HttpContext.Session.SetString("uid", hasUser.Id.ToString());

                    var userId = HttpContext.Session.GetString("uid");

                    return RedirectToAction("Create", "Blog");
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uid");
            return RedirectToAction("Login", "User");
        }
    }
}
