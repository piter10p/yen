using Yen.Scenes;
using Yen.TestGame.GameObjets;

namespace Yen.TestGame.Scenes
{
    public class TestSceneFactory : AbstractSceneFactory
    {
        public TestSceneFactory()
            : base(IdsProvider.ScenesFabrics.TestScene)
        {
            AddGameObject(new TestGameObjectFactory());
        }
    }
}
