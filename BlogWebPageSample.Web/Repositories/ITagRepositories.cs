using BlogWebPageSample.Web.Models.Domain;
using Microsoft.Identity.Client;

namespace BlogWebPageSample.Web.Repositories
{
    public interface ITagRepositories
    {
        IEnumerable<Tag> GetAll();
        Tag Get(Guid id);
        Tag Add(Tag tag);
        Tag? Update(Tag tag);
        Tag? Delete(Guid id);
    }
}
