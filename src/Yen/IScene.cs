using System.Collections.Generic;

namespace Yen
{
    public interface IScene
    {
        IList<IGameObject> GameObjects { get; }
        void Update(UpdateContext context);
        void Draw(DrawContext context);
        void Register(RegisterContext context);
        void OnLoad(OnLoadContext context);
    }
}
