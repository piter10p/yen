namespace Yen.Exceptions.AbstractGameObjectFactory
{
    public sealed class ComponentDeclaredException : YenException
    {
        public ComponentDeclaredException(string componentTypeName)
            : base($"Component declared already in game object factory. Component type: '{componentTypeName}'.")
        {
        }
    }
}
