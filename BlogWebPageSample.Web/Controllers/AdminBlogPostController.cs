using BlogWebPageSample.Web.Models.Domain;
using BlogWebPageSample.Web.Models.ViewModels;
using BlogWebPageSample.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWebPageSample.Web.Controllers
{
    public class AdminBlogPostController : Controller
    {
        private ITagRepositories tag;
        private IBlogPost blog;

        public AdminBlogPostController(ITagRepositories tagRepositories, IBlogPost blogPostRepo)
        {
            this.tag = tagRepositories;
            this.blog = blogPostRepo;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var tags = tag.GetAll();
            var model = new addBlogPostRepositories
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(addBlogPostRepositories addBlogPostRepositories)
        {
            var blogpost = new BlogPost
            {
                Heading = addBlogPostRepositories.Heading,
                PageTitle = addBlogPostRepositories.PageTitle,
                Content = addBlogPostRepositories.Content,
                ShortDescription = addBlogPostRepositories.ShortDescription,
                FaeaturedImageUrl = addBlogPostRepositories.FaeaturedImageUrl,
                UrlHandler = addBlogPostRepositories.UrlHandler,
                PublishedDate = addBlogPostRepositories.PublishedDate,
                Author = addBlogPostRepositories.Author,
                Visible = addBlogPostRepositories.Visible
            };
            var tags = new List<Tag>();
            foreach (var tagId in addBlogPostRepositories.SelectedTags)
            {
                var tagGuid = Guid.Parse(tagId);
                var existingTag = tag.Get(tagGuid);
                if (existingTag != null)
                {
                    tags.Add(existingTag);
                }
            }
            blogpost.Tags = tags;

            blog.Add(blogpost);

            return RedirectToAction("Add");
        }

        [HttpGet]
        public IActionResult List()
        {
            var blogpost = blog.GetAll();
            return View(blogpost);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var blogpost = blog.Get(id);
            var tagsDomainModel = tag.GetAll();
            if (blogpost != null)
            {
                var blogview = new EditBlogPostRequest
                {
                    Id = blogpost.Id,
                    Heading = blogpost.Heading,
                    PageTitle = blogpost.PageTitle,
                    Content = blogpost.Content,
                    ShortDescription = blogpost.ShortDescription,
                    FaeaturedImageUrl = blogpost.FaeaturedImageUrl,
                    UrlHandler = blogpost.UrlHandler,
                    PublishedDate = blogpost.PublishedDate,
                    Visible = blogpost.Visible,
                    Author = blogpost.Author,
                    Tags = tagsDomainModel.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }),

                    selectedTags = blogpost.Tags.Select(x => x.Id.ToString()).ToArray()
                };
                return View(blogview);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(EditBlogPostRequest blogPost)
        {
            var blogPostDomainModel = new BlogPost
            {
                Id = blogPost.Id,
                Heading = blogPost.Heading,
                PageTitle = blogPost.PageTitle,
                Content = blogPost.Content,
                ShortDescription = blogPost.ShortDescription,
                FaeaturedImageUrl = blogPost.FaeaturedImageUrl,
                UrlHandler = blogPost.UrlHandler,
                PublishedDate = blogPost.PublishedDate,
                Visible = blogPost.Visible,
                Author = blogPost.Author

            };

            var selectedTags = new List<Tag>();
            foreach (var selectedtag in blogPost.selectedTags)
            {
                if (Guid.TryParse(selectedtag,out var tagid))
                {
                    var foundtag = tag.Get(tagid);
                    if (foundtag != null)
                    {
                        selectedTags.Add(foundtag);
                    }
                }
            }
            blogPostDomainModel.Tags = selectedTags;

            var updatedBlog = blog.Update(blogPostDomainModel);
            if(updatedBlog!=null)
            {
                return RedirectToAction("Edit");
            }
            return RedirectToAction("Edit");
        }

        [HttpPost]
        public IActionResult Delete(EditBlogPostRequest editBlogPostRequest)
        {
            var deletedTag=blog.Delete(editBlogPostRequest.Id);
            if (deletedTag != null)
            {
                //success
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit",new { id=editBlogPostRequest.Id});
        }

    }
}
