using Blog.Database.Migrations;
using Blog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TestBlogAPI.Model;

namespace TestBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        BlogRepository blogRepository;


        public BlogController() 
        {
            blogRepository = new BlogRepository();
        
        }

        [HttpGet]
        public IEnumerable GetBlogs()
        {
            var blogList = blogRepository.GetAll();



            ICollection<Blogs> blogModel = blogList.Select(b => new Blogs
            {
                Id = b.Id,
                Title = b.title,
                Description = b.description,
            }).ToList();

            return blogModel;
        }

    }
}
