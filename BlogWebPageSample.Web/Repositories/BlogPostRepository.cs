using BlogWebPageSample.Web.Data;
using BlogWebPageSample.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogWebPageSample.Web.Repositories
{
    public class BlogPostRepository : IBlogPost
    {
        private BlogPostPageDBContextcs blog;
        public BlogPostRepository(BlogPostPageDBContextcs blogPost)
        {
            this.blog = blogPost;
            
        }
        public BlogPost Add(BlogPost blogPost)
        {
            blog.Add(blogPost);
            blog.SaveChanges();
            return blogPost;
        }

        public BlogPost? Delete(Guid id)
        {
            var check = blog.BlogPost.Find(id);
            if(check!=null)
            {
                blog.BlogPost.Remove(check);
                blog.SaveChanges();
                return check;

            }
            return null;
        }

        public BlogPost Get(Guid id)
        {
            return blog.BlogPost.Include(x => x.Tags).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<BlogPost> GetAll()
        {
            return blog.BlogPost.Include(x => x.Tags).ToList();
        }

        public BlogPost? Update(BlogPost blogPost)
        {
            var existingTag=blog.BlogPost.Include(x=>x.Tags).FirstOrDefault(x => x.Id == blogPost.Id);
            if(existingTag!=null)
            {
                existingTag.Id = blogPost.Id;
                existingTag.Heading = blogPost.Heading;
                existingTag.PageTitle = blogPost.PageTitle;
                existingTag.Content = blogPost.Content;
                existingTag.ShortDescription = blogPost.ShortDescription;
                existingTag.Author = blogPost.Author;
                existingTag.FaeaturedImageUrl = blogPost.FaeaturedImageUrl;
                existingTag.UrlHandler = blogPost.UrlHandler;
                existingTag.Visible = blogPost.Visible;
                existingTag.PublishedDate = blogPost.PublishedDate;
                existingTag.Tags = blogPost.Tags;

                blog.SaveChanges();
                return existingTag;
            }
            return null;
        }
    }
}
