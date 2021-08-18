using System;
using Yen.Content;
using Yen.Content.Contents;

namespace Yen.TestGame
{
    public static class ContentCollectionFabric
    {
        public static IContentCollection Create()
            => new ContentCollection()
            .AddContent(new Animation(
                ContentIdProvider.Animations.Smile,
                "Smile",
                3,
                TimeSpan.FromSeconds(1)));
    }
}
