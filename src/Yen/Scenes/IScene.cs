using System;
using System.Collections.Generic;

namespace Yen.Scenes
{
    public interface IScene
    {
        Guid Id { get; }
        int Layer { get; }
        IList<IGameObject> GameObjects { get; }
        void Update(UpdateContext context);
        void Draw(DrawContext context);
        void Register(RegistrationContext context);
        void Deregister(RegistrationContext context);
        void OnLoad(OnLoadContext context);
    }
}
