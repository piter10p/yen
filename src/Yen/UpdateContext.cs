using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Yen
{
    public class UpdateContext
    {
        public UpdateContext(
            GameTime gameTime,
            ContentManager contentManager)
        {
            GameTime = gameTime;
            ContentManager = contentManager;
        }

        public GameTime GameTime { get; }
        public ContentManager ContentManager { get; }
    }
}
