using System;
using System.Collections.Generic;
using Piranha.Models;
using Piranha.Repositories;

namespace Fase.Web.Repositories
{
    public interface IExtendedPageRepository : IPageRepository
    {
        IEnumerable<T> GetChildren<T>(Guid pageId) where T : GenericPage<T>;
    }
}