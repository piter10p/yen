namespace Yen.Exceptions.Content.Contents
{
    public sealed class ContentNotLoadedException: YenException
    {
        public ContentNotLoadedException(string id)
            : base($"Content not loaded yet. Use Load() method. Content id: '{id}'.")
        {
        }
    }
}
