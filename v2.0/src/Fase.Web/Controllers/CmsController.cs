using Microsoft.AspNetCore.Mvc;
using Piranha;
using System;

namespace Fase.Web.Controllers
{
    public class CmsController : Controller
    {
        private readonly IApi api;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="api">The current api</param>
        public CmsController(IApi api) {
            this.api = api;
        }

        ///// <summary>
        ///// Gets the blog archive with the given id.
        ///// </summary>
        ///// <param name="id">The unique page id</param>
        ///// <param name="year">The optional year</param>
        ///// <param name="month">The optional month</param>
        ///// <param name="page">The optional page</param>
        ///// <param name="category">The optional category</param>
        ///// <param name="tag">The optional tag</param>
        //[Route("archive")]
        //public IActionResult Archive(Guid id, int? year = null, int? month = null, int? page = null, 
        //    Guid? category = null, Guid? tag = null) 
        //{
        //    Models.BlogArchive model;

        //    if (category.HasValue)
        //        model = api.Archives.GetByCategoryId<Models.BlogArchive>(id, category.Value, page, year, month);
        //    else if (tag.HasValue)
        //        model = api.Archives.GetByTagId<Models.BlogArchive>(id, tag.Value, page, year, month);
        //    else model = api.Archives.GetById<Models.BlogArchive>(id, page, year, month);

        //    return View(model);
        //}

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("page")]
        public IActionResult Page(Guid id) {
            var model = api.Pages.GetById<Models.StandardPage>(id);

            return View(model);
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("partners")]
        public IActionResult Partners(Guid id)
        {
            var model = api.Pages.GetById<Models.PartnersPage>(id);

            return View(model);
        }

        ///// <summary>
        ///// Gets the post with the given id.
        ///// </summary>
        ///// <param name="id">The unique post id</param>
        //[Route("post")]
        //public IActionResult Post(Guid id) {
        //    var model = api.Posts.GetById<Models.BlogPost>(id);

        //    return View(model);
        //}

        /// <summary>
        /// Gets the startpage with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("")]
        public IActionResult Start(Guid id) {
            var model = api.Pages.GetById<Models.StartPage>(id);

            return View(model);
        }
    }
}
