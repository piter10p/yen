using System.Collections.Generic;

namespace Yen
{
    public interface ILoadableComponent : IComponent
    {
        ISet<string> RequiredContentsIds { get; }
        void OnLoad(OnLoadContext context, IGameObject obj);
    }
}
