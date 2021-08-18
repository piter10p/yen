using System;

namespace Yen.Exceptions.Content.Contents
{
    public sealed class ContentLoadingException : YenException
    {
        public ContentLoadingException(string id, Exception innerException)
            : base($"Failed to load content with id: '{id}'. Reason: '{innerException.Message}'.", innerException)
        {
        }
    }
}
