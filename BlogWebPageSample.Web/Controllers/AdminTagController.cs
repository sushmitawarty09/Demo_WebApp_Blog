using BlogWebPageSample.Web.Data;
using BlogWebPageSample.Web.Models.Domain;
using BlogWebPageSample.Web.Models.ViewModels;
using BlogWebPageSample.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebPageSample.Web.Controllers
{
    public class AdminTagController : Controller
    {
        private ITagRepositories tagRepositories;
        public AdminTagController(ITagRepositories tagRepositories)
        {
            this.tagRepositories = tagRepositories;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(addTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };
            tagRepositories.Add(tag);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List()
        {
            var tags = tagRepositories.GetAll();
            return View(tags);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var tag = tagRepositories.Get(id);
            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };
                return View(editTagRequest);
            }
            return View(null);
        }
        [HttpPost]
        public IActionResult Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var updatedTag = tagRepositories.Update(tag);
            if (updatedTag != null)
            {
                //success
            }
            else
            {
                //error
            }
            return RedirectToAction("Edit", new { id = updatedTag.Id });
        }
        [HttpPost]
        public IActionResult Delete(EditTagRequest editTagRequest)
        {
            var tag = tagRepositories.Delete(editTagRequest.Id);
            if (tag.Id != null)
            {
                //success
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id = tag.Id });
        }
    }
}
