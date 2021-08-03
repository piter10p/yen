namespace Yen.Exceptions.GraphicsComponents
{
    public sealed class AnimationNotLoadedException : YenException
    {
        public AnimationNotLoadedException(string animationName)
            : base($"Animation not loaded yet. Use Load() method. Animation name: '{animationName}'.")
        {

        }
    }
}
