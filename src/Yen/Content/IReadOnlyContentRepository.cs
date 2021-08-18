namespace Yen.Content
{
    public interface IReadOnlyContentRepository
    {
        IContent GetContent(string id);
    }
}
