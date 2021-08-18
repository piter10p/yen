using System.Collections.Generic;

namespace Yen.Content
{
    public interface IContentCollection
    {
        IEnumerable<IContent> Contents { get; }
        IContentCollection AddContent(IContent content);
    }
}
