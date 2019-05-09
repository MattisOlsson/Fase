using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Piranha;
using Piranha.Models;
using Piranha.Repositories;
using Piranha.Services;

namespace Fase.Web.Repositories
{
    public class ExtendedPageRepository : PageRepository, IExtendedPageRepository
    {
        private readonly IDb _db;

        public ExtendedPageRepository(IApi api, IDb db, IContentServiceFactory factory, ICache cache = null) : base(api, db, factory, cache)
        {
            _db = db;
        }

        public virtual IEnumerable<T> GetChildren<T>(Guid pageId) where T : GenericPage<T>
        {
            var queryable = this._db.Pages.AsNoTracking().Where(p => p.ParentId == pageId).OrderBy(p => p.SortOrder).Select(p => p.Id);
            var objList = new List<T>();

            foreach (var id in queryable)
            {
                T byId = this.GetById<T>(id);
                if (byId != null)
                    objList.Add(byId);
            }

            return objList;
        }
    }
}