using System;

namespace Yen.Content
{
    public interface IReadOnlyContentRepository
    {
        IContent GetContent(Guid id);
    }
}
