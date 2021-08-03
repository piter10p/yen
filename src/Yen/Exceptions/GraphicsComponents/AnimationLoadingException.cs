using System;

namespace Yen.Exceptions.GraphicsComponents
{
    public sealed class AnimationLoadingException : YenException
    {
        public AnimationLoadingException(string animationName, Exception innerException)
            : base($"Failed to load animation with name: '{animationName}'. Reason: '{innerException.Message}'.", innerException)
        {
        }
    }
}
