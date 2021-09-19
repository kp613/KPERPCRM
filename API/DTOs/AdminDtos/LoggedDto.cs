namespace API.DTOs.AdminDtos
{
    public class LoggedDto
    {
        public string Username { get; set; }
        //public string Email { get; set; }
        public string Token { get; set; }
        public int StaffId { get; set; }
        //public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string KnownAs { get; set; }
        public string Gender { get; set; }
    }
}