using Microsoft.Xna.Framework;
using System;
using Yen.GraphicsComponents;

namespace Yen.TestGame.GameObjets
{
    public class TestGameObjectFactory : AbstractGameObjectFactory
    {
        public TestGameObjectFactory()
        {
            SetInitialPosition(new Vector2(100, 100));

            var animation = new Animation(
                "SMILE",
                "Smile",
                2,
                TimeSpan.FromSeconds(1));

            AddComponent(new AnimatedGraphicsComponent(new[] { animation }, Color.White));
        }
    }
}
