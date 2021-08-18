namespace Yen.Content
{
    public interface IContentRepository : IReadOnlyContentRepository
    {
        void AddUsage(string id);
        void RemoveUsage(string id);
        void Load(LoadContext context);
        void Unload();
    }
}
