namespace Yen.UnitTests.Mocks.Components
{
    public class LogicComponentMock : ILogicComponent
    {
        public int UpdateCounter { get; private set; } = 0;

        public void Update(UpdateContext context, IGameObject obj)
        {
            UpdateCounter++;
        }
    }
}
