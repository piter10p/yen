namespace Yen
{
    public interface ILogicComponent
    {
        void OnLoad(LoadContext context, IGameObject obj);
        void Update(UpdateContext context, IGameObject obj);
    }
}
