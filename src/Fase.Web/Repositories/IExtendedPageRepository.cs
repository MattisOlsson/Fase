using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Piranha.Models;
using Piranha.Repositories;

namespace Fase.Web.Repositories
{
    public interface IExtendedPageRepository : IPageRepository
    {
        Task<IEnumerable<T>> GetChildrenAsync<T>(Guid pageId) where T : GenericPage<T>;
    }
}