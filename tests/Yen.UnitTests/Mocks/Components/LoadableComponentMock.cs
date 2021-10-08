using System;
using System.Collections.Generic;

namespace Yen.UnitTests.Mocks.Components
{
    public class LoadableComponentMock : ILoadableComponent
    {
        private readonly HashSet<Guid> _requiredContentsIds;
        public ISet<Guid> RequiredContentsIds => _requiredContentsIds;

        public LoadableComponentMock(HashSet<Guid> requiredContentsIds)
        {
            _requiredContentsIds = requiredContentsIds;
        }

        public MethodCounter OnLoadCounter { get; } = new MethodCounter();

        public void OnLoad(OnLoadContext context, IGameObject obj)
        {
            OnLoadCounter.Call();
        }
    }
}
