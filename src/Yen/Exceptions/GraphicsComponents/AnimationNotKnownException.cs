namespace Yen.Exceptions.GraphicsComponents
{
    public sealed class AnimationNotKnownException : YenException
    {
        public AnimationNotKnownException(string animationName) : base($"Animation name not known for component: '{animationName}'.")
        {
        }
    }
}
