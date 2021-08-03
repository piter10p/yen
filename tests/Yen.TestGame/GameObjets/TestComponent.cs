using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Yen.TestGame.GameObjets
{
    public class TestComponent : IGraphicsComponent
    {
        private SpriteBatch _sprite;
        private Texture2D _texture;

        public void Draw(DrawContext context, IGameObject obj)
        {
            _sprite.Begin();
            _sprite.Draw(_texture, obj.Position, Color.White);
            _sprite.End();
        }


        public void OnLoad(LoadContext context, IGameObject obj)
        {
            _sprite = new SpriteBatch(context.GraphicsDevice);
            _texture = context.ContentManager.Load<Texture2D>("smile");
        }
    }
}
