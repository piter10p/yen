using Yen.Content;

namespace Yen
{
    public class RegistrationContext
    {
        public RegistrationContext(IContentRepository contentRepository)
        {
            ContentRepository = contentRepository;
        }

        public IContentRepository ContentRepository { get; }
    }
}
