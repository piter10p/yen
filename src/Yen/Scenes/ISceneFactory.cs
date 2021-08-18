using System;

namespace Yen.Scenes
{
    public interface ISceneFactory
    {
        Guid Id { get; }
        IScene Create(Guid sceneId);
    }
}
