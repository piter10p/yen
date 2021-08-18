namespace Yen
{
    public interface IGraphicsComponent : IComponent
    {
        void Draw(DrawContext context, IGameObject obj);
    }
}
