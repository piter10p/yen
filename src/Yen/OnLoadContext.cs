using Microsoft.Xna.Framework.Graphics;
using Yen.Content;

namespace Yen
{
    public class OnLoadContext
    {
        public OnLoadContext(
            GraphicsDevice graphicsDevice,
            IReadOnlyContentRepository contentRepository)
        {
            GraphicsDevice = graphicsDevice;
            ContentRepository = contentRepository;
        }

        public GraphicsDevice GraphicsDevice { get; }
        public IReadOnlyContentRepository ContentRepository { get; }
    }
}
