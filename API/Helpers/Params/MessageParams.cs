using API.Helpers.Pagination;

namespace API.Helpers.Params
{
    public class MessageParams : PageParams
    {
        public string Username { get; set; }
        public string Container { get; set; } = "Unread";
    }
}
