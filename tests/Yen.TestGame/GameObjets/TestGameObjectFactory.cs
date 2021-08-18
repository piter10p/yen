using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Yen.GraphicsComponents;

namespace Yen.TestGame.GameObjets
{
    public class TestGameObjectFactory : AbstractGameObjectFactory
    {
        public TestGameObjectFactory()
        {
            SetInitialPosition(new Vector2(100, 100));

            var animations = new HashSet<Guid>()
            {
                ContentIdProvider.Animations.Smile
            };

            AddComponent(new AnimatedGraphicsComponent(animations, Color.White, AnimationPlayMode.PingPong));
        }
    }
}
