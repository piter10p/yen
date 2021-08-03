using Microsoft.Xna.Framework;

namespace Yen.TestGame.GameObjets
{
    public class TestGameObjectFactory : AbstractGameObjectFactory
    {
        public TestGameObjectFactory()
        {
            SetInitialPosition(new Vector2(100, 100));
            AddComponent(new TestComponent());
        }
    }
}
