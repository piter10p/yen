namespace Yen.UnitTests.Mocks.Components
{
    public class LogicComponentMock : ILogicComponent
    {
        public MethodCounter UpdateCounter { get; } = new MethodCounter();

        public void Update(UpdateContext context, IGameObject obj)
        {
            UpdateCounter.Call();
        }
    }
}
