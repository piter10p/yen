namespace Yen.UnitTests.Mocks.Components
{
    public class GraphicsComponentMock : IGraphicsComponent
    {
        public int DrawCounter { get; private set; } = 0;

        public void Draw(DrawContext context, IGameObject obj)
        {
            DrawCounter++;
        }
    }
}
