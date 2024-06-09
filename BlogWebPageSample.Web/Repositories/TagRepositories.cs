using Azure;
using BlogWebPageSample.Web.Data;
using BlogWebPageSample.Web.Models.Domain;
using BlogWebPageSample.Web.Models.ViewModels;

namespace BlogWebPageSample.Web.Repositories
{
    public class TagRepositories : ITagRepositories
    {
        private BlogPostPageDBContextcs blogPostPageDBContext;

        public TagRepositories(BlogPostPageDBContextcs blogPostPageDBContextcs)
        {
            this.blogPostPageDBContext = blogPostPageDBContextcs;
        }
        public Tag Add(Tag tag)
        {
            blogPostPageDBContext.Tags.Add(tag);
            blogPostPageDBContext.SaveChanges();
            return tag;
        }

        public Tag? Delete(Guid id)
        {
            var tag = blogPostPageDBContext.Tags.Find(id);
            if (tag != null)
            {
                blogPostPageDBContext.Tags.Remove(tag);
                blogPostPageDBContext.SaveChanges();
                return tag;
            }
            return null;
        }

        public Tag Get(Guid id)
        {
            return blogPostPageDBContext.Tags.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return blogPostPageDBContext.Tags.ToList();
        }

        public Tag? Update(Tag tag)
        {
            var existingTag = blogPostPageDBContext.Tags.Find(tag.Id);
            if(existingTag !=null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;
                blogPostPageDBContext.SaveChanges();
                return existingTag;
            }
            return null;
        }
    }
}
