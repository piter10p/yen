using Microsoft.Xna.Framework;

namespace Yen
{
    public class UpdateContext
    {
        public UpdateContext(GameTime gameTime)
        {
            GameTime = gameTime;
        }

        public GameTime GameTime { get; }
    }
}
