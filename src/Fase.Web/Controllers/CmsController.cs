using Microsoft.AspNetCore.Mvc;
using Piranha;
using System;
using System.Linq;
using System.Threading.Tasks;
using Fase.Web.Models;
using Fase.Web.Models.ViewModels;
using Fase.Web.Repositories;
using Piranha.Services;

namespace Fase.Web.Controllers
{
    public class CmsController : Controller
    {
        private readonly IApi _api;
        private readonly IExtendedPageRepository _extendedPageRepository;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <param name="extendedPageRepository"></param>
        public CmsController(IApi api, IExtendedPageRepository extendedPageRepository)
        {
            _api = api;
            _extendedPageRepository = extendedPageRepository;
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("page")]
        public IActionResult Page(Guid id) {
            var model = _api.Pages.GetById<StandardPage>(id);

            return View(model);
        }

        /// <summary>
        /// Gets the event listing page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("events")]
        public async Task<IActionResult> Events(Guid id)
        {
            var page = _api.Pages.GetById<EventListingPage>(id);
            var events = await _extendedPageRepository.GetChildrenAsync<EventPage>(id);
            var model = new EventsListingView(page)
            {
                Events = events.Where(x => x.StartDate.HasValue && x.EndDate.HasValue && x.EndDate.Value > DateTime.Now)
            };

            return View(model);
        }

        /// <summary>
        /// Gets the event page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("event")]
        public IActionResult Event(Guid id)
        {
            var model = _api.Pages.GetById<EventPage>(id);

            return View(model);
        }

        /// <summary>
        /// Gets the partners page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("partners")]
        public IActionResult Partners(Guid id)
        {
            var model = _api.Pages.GetById<PartnersPage>(id);

            return View(model);
        }

        /// <summary>
        /// Gets the artist listing page with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("artists")]
        public IActionResult Artists(Guid id)
        {
            var model = _api.Pages.GetById<ArtistListingPage>(id);

            return View(model);
        }

        /// <summary>
        /// Gets the startpage with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("eventschedules")]
        public async Task<IActionResult> EventSchedules(Guid id)
        {
            var page = _api.Pages.GetById<EventScheduleListingPage>(id);
            var model = new EventScheduleListingView
            {
                Title = page.Title,
                Hero = page.Hero,
                Blocks = page.Blocks,
                Schedules = await _extendedPageRepository.GetChildrenAsync<EventSchedulePage>(id)
            };

            return View(model);
        }

        /// <summary>
        /// Gets the startpage with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("eventschedule")]
        public IActionResult EventSchedule(Guid id)
        {
            var model = _api.Pages.GetById<Models.EventSchedulePage>(id);

            return View(model);
        }

        /// <summary>
        /// Gets the startpage with the given id.
        /// </summary>
        /// <param name="id">The unique page id</param>
        [Route("")]
        public IActionResult Start(Guid id) {
            var model = _api.Pages.GetById<StartPage>(id);

            return View(model);
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

        ///// <summary>
        ///// Gets the post with the given id.
        ///// </summary>
        ///// <param name="id">The unique post id</param>
        //[Route("post")]
        //public IActionResult Post(Guid id) {
        //    var model = api.Posts.GetById<Models.BlogPost>(id);

        //    return View(model);
        //}
    }
}
