using System;

namespace Yen.Exceptions.Scenes
{
    public class SceneNotLoadedException : YenException
    {
        public SceneNotLoadedException(Guid sceneId)
            : base($"Scene is not loaded. Id: '{sceneId}'.")
        {
            SceneId = sceneId;
        }

        public Guid SceneId { get; }
    }
}
