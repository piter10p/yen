using System.Collections.Generic;
using Yen.Content;

namespace Yen.Extensions
{
    public static class ContentRepositoryExtensions
    {
        public static void AddUsages(this IContentRepository repository, ISet<string> contentsIds)
        {
            foreach (var c in contentsIds)
            {
                repository.AddUsage(c);
            }
        }
    }
}
