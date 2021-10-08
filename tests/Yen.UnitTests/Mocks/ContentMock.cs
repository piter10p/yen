using System;
using Yen.Content;

namespace Yen.UnitTests.Mocks
{
    public class ContentMock : IContent
    {
        private readonly Guid _id;
        private bool _loaded;

        public ContentMock(
            Guid? id = null,
            bool? loaded = null)
        {
            _id = id ?? Guid.Empty;
            _loaded = loaded ?? false;
        }

        public Guid Id => _id;

        public bool Loaded => _loaded;

        public MethodCounter LoadCount { get; } = new MethodCounter();
        public MethodCounter UnloadCount { get; } = new MethodCounter();

        public void Load(LoadContext context)
        {
            LoadCount.Call();
        }

        public void Unload()
        {
            UnloadCount.Call();
        }
    }
}
