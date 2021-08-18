using System;

namespace Yen.Exceptions.Content
{
    public class ContentRegisteredAlreadyException : YenException
    {
        public ContentRegisteredAlreadyException(Guid id) : base($"Content registered already. Id: '{id}'.")
        {
        }
    }
}
