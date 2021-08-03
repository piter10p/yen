using Yen.TestGame.GameObjets;

namespace Yen.TestGame.Scenes
{
    public class TestSceneFactory : AbstractSceneFactory
    {
        public TestSceneFactory()
        {
            AddGameObject(new TestGameObjectFactory());
        }
    }
}
