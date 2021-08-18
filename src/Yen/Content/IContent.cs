using Microsoft.Xna.Framework.Content;

namespace Yen.Content
{
    public interface IContent
    {
        string Id { get; }
        bool Loaded { get; }
        void Load(LoadContext context);
        void Unload();
    }
}
