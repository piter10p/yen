namespace Yen.Exceptions.Content
{
    public class ContentNotRegisteredException : YenException
    {
        public ContentNotRegisteredException(string id) : base($"Content not registered. Id: '{id}'.")
        {
        }
    }
}
