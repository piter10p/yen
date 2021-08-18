namespace Yen.Scenes
{
    public interface IScenesUpdater
    {
        void Update(UpdateContext context);
        void Draw(DrawContext context);
    }
}
