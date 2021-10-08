using System;
using System.Collections.Generic;
using System.Linq;
using Yen.Extensions;

namespace Yen.Content
{
    public class ContentRepository : IContentRepository
    {
        private readonly Dictionary<Guid, ContentEntry> _contnets;

        public ContentRepository(IContentSource contentSource)
        {
            _contnets = contentSource.Contents.ToDictionary(k => k.Id, v => new ContentEntry(v));
        }

        public IContent GetContent(Guid id)
        {
            _contnets.CheckIsContentRegistered(id);
            return _contnets[id].Content;
        }

        public void AddUsage(Guid id)
        {
            _contnets.CheckIsContentRegistered(id);
            var content = _contnets[id];
            content.Usages++;
        }

        public void RemoveUsage(Guid id)
        {
            _contnets.CheckIsContentRegistered(id);
            var content = _contnets[id];
            content.Usages--;
        }

        public void AddUsages(ISet<Guid> ids)
        {
            _contnets.CheckIsContentRegistered(ids);

            foreach (var id in ids)
            {
                _contnets[id].Usages++;
            }
        }

        public void RemoveUsages(ISet<Guid> ids)
        {
            _contnets.CheckIsContentRegistered(ids);

            foreach (var id in ids)
            {
                _contnets[id].Usages--;
            }
        }

        public void Load(LoadContext context)
        {
            foreach (var c in _contnets)
            {
                if (c.Value.Usages > 0 && !c.Value.Content.Loaded)
                    c.Value.Content.Load(context);
            }
        }

        public void Unload()
        {
            foreach (var c in _contnets)
            {
                if (c.Value.Usages == 0 && c.Value.Content.Loaded)
                    c.Value.Content.Unload();
            }
        }
    }
}
