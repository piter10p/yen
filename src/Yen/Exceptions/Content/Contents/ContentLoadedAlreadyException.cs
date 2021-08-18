namespace Yen.Exceptions.Content.Contents
{
    public sealed class ContentLoadedAlreadyException : YenException
    {
        public ContentLoadedAlreadyException(string id)
            : base($"Content loaded already. Content id: '{id}'.")
        {
        }
    }
}
