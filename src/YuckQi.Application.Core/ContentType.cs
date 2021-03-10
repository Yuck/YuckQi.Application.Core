using MimeContentType = System.Net.Mime.ContentType;

namespace YuckQi.Application.Core
{
    // TODO: Where should this really go? It's specific to one type of host (i.e. web host) rather than a generic application
    public static class ContentType
    {
        public static MimeContentType ApplicationJson = new MimeContentType("application/json");
    }
}