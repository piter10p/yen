using System;
using System.Collections.Generic;
using Yen.Content;
using Yen.Content.Contents;

namespace Yen.TestGame
{
    public class ContentSource : IContentSource
    {
        public IEnumerable<IContent> Contents { get; } = new IContent[]
        {
            new Animation(
                IdsProvider.Contents.Animations.Smile,
                "Smile",
                3,
                TimeSpan.FromSeconds(1))
        };
    }
}
