using System.Collections.Generic;
using Yen.Scenes;
using Yen.TestGame.Scenes;

namespace Yen.TestGame
{
    public class ScenesFactoriesSource : IScenesFactoriesSource
    {
        public IEnumerable<ISceneFactory> Factories { get; } = new ISceneFactory[]
        {
            new TestSceneFactory()
        };
    }
}
