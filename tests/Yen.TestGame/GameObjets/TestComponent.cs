using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;

namespace Yen.TestGame.GameObjets
{
    public class TestComponent : IComponent
    {
        private SpriteBatch _sprite;
        private Texture2D _texture;

        public Task OnLoad(LoadContext context, IGameObject obj)
        {
            _sprite = new SpriteBatch(context.GraphicsDevice);
            _texture = context.ContentManager.Load<Texture2D>("smile");
            return Task.CompletedTask;
        }

        public void Update(UpdateContext context, IGameObject obj)
        {
            _sprite.Begin();
            _sprite.Draw(_texture, obj.Position, Color.White);
            _sprite.End();
        }
    }
}
