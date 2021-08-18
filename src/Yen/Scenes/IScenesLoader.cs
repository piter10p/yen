using System;

namespace Yen.Scenes
{
    public interface IScenesLoader
    {
        Guid LoadScene(Guid factoryId, int layer);
        void UnloadScene(Guid sceneId);
    }
}
