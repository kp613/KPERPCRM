using API.Helpers.Pagination;

namespace API.Helpers.Params
{
    public class UserParams : PageParams
    {
        public string CurrentUsername { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; } = 18;
        public int MaxAge { get; set; } = 90;
        public string OrderBy { get; set; } = "lastActive";
    }
}
