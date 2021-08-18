using System;
using System.Collections.Generic;
using Yen.Exceptions.Content;

namespace Yen.Content
{
    public class ContentCollection : IContentCollection
    {
        private Dictionary<Guid, IContent> _contnets = new Dictionary<Guid, IContent>();

        public IEnumerable<IContent> Contents
            => _contnets.Values;

        public IContentCollection AddContent(IContent content)
        {
            if (content is null) throw new ArgumentNullException(nameof(content));

            if (content is null) throw new ArgumentNullException(nameof(content));

            if (_contnets.ContainsKey(content.Id))
                throw new ContentRegisteredAlreadyException(content.Id);

            _contnets.Add(content.Id, content);

            return this;
        }
    }
}
