using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Yen
{
    public class LoadContext
    {
        public LoadContext(
            ContentManager contentManager,
            GraphicsDevice graphicsDevice)
        {
            ContentManager = contentManager;
            GraphicsDevice = graphicsDevice;
        }

        public ContentManager ContentManager { get; }
        public GraphicsDevice GraphicsDevice { get; }
    }
}
