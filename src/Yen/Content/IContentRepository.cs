using System;
using System.Collections.Generic;

namespace Yen.Content
{
    public interface IContentRepository : IReadOnlyContentRepository
    {
        void AddUsage(Guid id);
        void AddUsages(ISet<Guid> ids);
        void RemoveUsage(Guid id);
        void RemoveUsages(ISet<Guid> ids);
        void Load(LoadContext context);
        void Unload();
    }
}
