namespace Yen
{
    public interface ILogicComponent : IComponent
    {
        void Update(UpdateContext context, IGameObject obj);
    }
}
