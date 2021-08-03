namespace Yen.Exceptions.GraphicsComponents
{
    public sealed class NoActiveAnimationException : YenException
    {
        public NoActiveAnimationException() : base("No active animation in component.")
        {
        }
    }
}
