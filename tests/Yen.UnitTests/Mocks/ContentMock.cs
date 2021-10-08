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

        public int LoadCount { get; private set; } = 0;
        public int UnloadCount { get; private set; } = 0;

        public void Load(LoadContext context)
        {
            LoadCount++;
        }

        public void Unload()
        {
            UnloadCount++;
        }
    }
}
