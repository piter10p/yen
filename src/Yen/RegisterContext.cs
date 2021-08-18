using Yen.Content;

namespace Yen
{
    public class RegisterContext
    {
        public RegisterContext(IContentRepository contentRepository)
        {
            ContentRepository = contentRepository;
        }

        public IContentRepository ContentRepository { get; }
    }
}
