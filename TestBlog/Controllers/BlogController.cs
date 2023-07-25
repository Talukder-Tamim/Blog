using Blog.Models.EntityModels;
using Blog.Repositories;
using Microsoft.AspNetCore.Mvc;
using TestBlog.Models;

namespace TestBlog.Controllers
{
    public class BlogController : Controller
    {
        BlogRepository repository;
        
        public BlogController()
        {
            repository = new BlogRepository();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Posts()
        {
            return View(); 
        }
        public IActionResult Create(CreatePost model)
        {
            var userId = HttpContext.Session.GetString("uid");

            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                var blog = new BlogPost()
                {
                    title = model.title,
                    description = model.description,
                    image = model.image,
                    UsersId = int.Parse(userId)

                };

                bool _isSuccess = repository.Add(blog);

                if (_isSuccess)
                {
                    return View();
                }
            }
            return View();
        }

    }
}
