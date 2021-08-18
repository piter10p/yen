using System;
using System.Collections.Generic;
using System.Linq;
using Yen.Exceptions.Content;

namespace Yen.Content
{
    public class ContentRepository : IContentRepository
    {
        private readonly Dictionary<string, ContentEntry> _contnets;

        public ContentRepository(IContentCollection contentCollection)
        {
            _contnets = contentCollection.Contents.ToDictionary(k => k.Id, v => new ContentEntry(v));
        }

        public IContent GetContent(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));

            if (!_contnets.ContainsKey(id))
                throw new ContentNotRegisteredException(id);

            return _contnets[id].Content;
        }

        public void AddUsage(string id)
        {
            if (!_contnets.ContainsKey(id))
                throw new ContentNotRegisteredException(id);

            var content = _contnets[id];
            content.Usages++;
        }

        public void RemoveUsage(string id)
        {
            if (!_contnets.ContainsKey(id))
                throw new ContentNotRegisteredException(id);

            var content = _contnets[id];
            content.Usages--;
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
