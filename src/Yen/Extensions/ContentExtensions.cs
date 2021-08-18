using Yen.Content;
using Yen.Exceptions.Extensions;

namespace Yen.Extensions
{
    public static class ContentExtensions
    {
        public static T As<T>(this IContent component) where T : IContent
        {
            if(!(component is T))
                throw new ContentIsNotExpectedTypeException(typeof(T), component.GetType());

            return (T)component;
        }
    }
}
