using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Yen
{
    public class UpdateContext
    {
        public UpdateContext(
            GameTime gameTime,
            GraphicsDevice graphicsDevice,
            ContentManager contentManager)
        {
            GameTime = gameTime;
            GraphicsDevice = graphicsDevice;
            ContentManager = contentManager;
        }

        public GameTime GameTime { get; }
        public GraphicsDevice GraphicsDevice { get; }
        public ContentManager ContentManager { get; }
    }
}
