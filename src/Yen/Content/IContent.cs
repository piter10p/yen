using System;

namespace Yen.Content
{
    public interface IContent
    {
        Guid Id { get; }
        bool Loaded { get; }
        void Load(LoadContext context);
        void Unload();
    }
}
