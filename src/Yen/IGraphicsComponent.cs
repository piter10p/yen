namespace Yen
{
    public interface IGraphicsComponent
    {
        void OnLoad(LoadContext loadContext, IGameObject obj);
        void Draw(DrawContext context, IGameObject obj);
    }
}
