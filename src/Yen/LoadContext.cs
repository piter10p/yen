using Microsoft.Xna.Framework.Content;

namespace Yen
{
    public class LoadContext
    {
        public LoadContext(ContentManager contentManager)
        {
            ContentManager = contentManager;
        }

        public ContentManager ContentManager { get; }
    }
}
