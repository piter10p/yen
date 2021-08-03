namespace Yen.Exceptions.GraphicsComponents
{
    public sealed class AnimationLoadedAlreadyException : YenException
    {
        public AnimationLoadedAlreadyException(string animationName)
            : base($"Animation loaded already. Animation name: '{animationName}'.")
        {
        }
    }
}
