using System;

namespace Yen.Exceptions.Content.Contents
{
    public sealed class ContentLoadedAlreadyException : YenException
    {
        public ContentLoadedAlreadyException(Guid id)
            : base($"Content loaded already. Content id: '{id}'.")
        {
        }
    }
}
