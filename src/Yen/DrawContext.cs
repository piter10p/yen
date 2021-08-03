using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Yen
{
    public class DrawContext
    {
        public DrawContext(
            GameTime gameTime,
            GraphicsDevice graphicsDevice)
        {
            GameTime = gameTime;
            GraphicsDevice = graphicsDevice;
        }

        public GameTime GameTime { get; }
        public GraphicsDevice GraphicsDevice { get; }
    }
}
