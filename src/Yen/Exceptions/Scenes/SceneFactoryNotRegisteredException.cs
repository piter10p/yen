using System;

namespace Yen.Exceptions.Scenes
{
    public class SceneFactoryNotRegisteredException : YenException
    {
        public SceneFactoryNotRegisteredException(Guid fabricId)
            : base($"Scene factory not registered. Id: '{fabricId}'.")
        {
            FabricId = fabricId;
        }

        public Guid FabricId { get; }
    }
}
