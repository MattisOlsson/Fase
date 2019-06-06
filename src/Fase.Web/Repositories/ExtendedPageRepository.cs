using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ExtendedPageRepository(IDb db, IContentServiceFactory factory) : base(db, factory)
        {
            _db = db;
        }

        public virtual async Task<IEnumerable<T>> GetChildrenAsync<T>(Guid pageId) where T : GenericPage<T>
        {
            var queryable = _db.Pages.AsNoTracking().Where(p => p.ParentId == pageId).OrderBy(p => p.SortOrder).Select(p => p.Id);
            var objList = new List<T>();

            foreach (var id in queryable)
            {
                var byId = await GetById<T>(id);

                if (byId != null)
                    objList.Add(byId);
            }

            return objList;
        }
    }
}