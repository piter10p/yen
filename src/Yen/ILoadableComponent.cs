using System;
using System.Collections.Generic;

namespace Yen
{
    public interface ILoadableComponent : IComponent
    {
        ISet<Guid> RequiredContentsIds { get; }
        void OnLoad(OnLoadContext context, IGameObject obj);
    }
}
