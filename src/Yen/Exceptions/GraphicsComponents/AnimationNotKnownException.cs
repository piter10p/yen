namespace Yen.Exceptions.GraphicsComponents
{
    public sealed class AnimationNotKnownException : YenException
    {
        public AnimationNotKnownException(string animationId) : base($"Animation id not known for component: '{animationId}'.")
        {
        }
    }
}
