using Blog.Database;
using Blog.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public class BlogRepository
    {
        ApplicationDbContext _db;

        public BlogRepository()
        {
            _db = new ApplicationDbContext();
        }

        public bool Add(BlogPost blog)
        {
            _db.BlogPost.Add(blog);
            return _db.SaveChanges() > 0;
        }

        public ICollection<BlogPost> GetAll()
        {
            return _db.BlogPost.ToList();
        }
    }
}
