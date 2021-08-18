using System.Collections.Generic;

namespace Yen.Scenes
{
    public interface IScenesFactoriesSource
    {
        IEnumerable<ISceneFactory> Factories { get; }
    }
}
