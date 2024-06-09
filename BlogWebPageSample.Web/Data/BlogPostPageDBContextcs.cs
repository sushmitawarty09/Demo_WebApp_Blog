using BlogWebPageSample.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogWebPageSample.Web.Data
{
    public class BlogPostPageDBContextcs : DbContext
    {
        public BlogPostPageDBContextcs(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BlogPost>  BlogPost { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
