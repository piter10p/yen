namespace Yen.Content
{
    public class ContentEntry
    {
        public ContentEntry(IContent content)
        {
            Content = content;
            Usages = 0;
        }

        public IContent Content { get; }
        public int Usages { get; set; }
    }
}
