using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models.EntityModels
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string? image { get; set; }

        public int? UsersId { get; set; }
        public Users Users { get; set; }
    }
}
