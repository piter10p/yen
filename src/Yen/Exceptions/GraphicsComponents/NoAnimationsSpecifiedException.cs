namespace Yen.Exceptions.GraphicsComponents
{
    public class NoAnimationsSpecifiedException : YenException
    {
        public NoAnimationsSpecifiedException()
            : base("No animation specified.")
        {
        }
    }
}
