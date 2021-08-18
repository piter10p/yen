using System;

namespace Yen.Exceptions.Content.Contents
{
    public sealed class ContentNotLoadedException: YenException
    {
        public ContentNotLoadedException(Guid id)
            : base($"Content not loaded yet. Use Load() method. Content id: '{id}'.")
        {
        }
    }
}
