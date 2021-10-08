namespace Yen.UnitTests.Mocks.Components
{
    public class GraphicsComponentMock : IGraphicsComponent
    {
        public MethodCounter DrawCounter { get; } = new MethodCounter();

        public void Draw(DrawContext context, IGameObject obj)
        {
            DrawCounter.Call();
        }
    }
}
