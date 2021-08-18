using System;

namespace Yen.Exceptions.GraphicsComponents
{
    public sealed class AnimationNotKnownException : YenException
    {
        public AnimationNotKnownException(Guid animationId) : base($"Animation id not known for component: '{animationId}'.")
        {
        }
    }
}
