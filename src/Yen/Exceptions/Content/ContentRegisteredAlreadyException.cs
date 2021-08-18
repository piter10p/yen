namespace Yen.Exceptions.Content
{
    public class ContentRegisteredAlreadyException : YenException
    {
        public ContentRegisteredAlreadyException(string id) : base($"Content registered already. Id: '{id}'.")
        {
        }
    }
}
