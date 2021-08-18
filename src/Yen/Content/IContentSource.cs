using System.Collections.Generic;

namespace Yen.Content
{
    public interface IContentSource
    {
        IEnumerable<IContent> Contents { get; }
    }
}
