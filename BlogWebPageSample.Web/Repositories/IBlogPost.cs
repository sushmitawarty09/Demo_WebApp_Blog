using BlogWebPageSample.Web.Models.Domain;

namespace BlogWebPageSample.Web.Repositories
{
    public interface IBlogPost
    {
        public BlogPost Get(Guid id);
        public IEnumerable<BlogPost?> GetAll();
        public BlogPost Add(BlogPost blogPost);
        public BlogPost? Update(BlogPost blogPost);
        public BlogPost? Delete(Guid id);
    }
}
