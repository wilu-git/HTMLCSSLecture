namespace HTMLCSSLecture.Models
{
    public class UserDetailsModel
    {
        public int Userid { get; set; }
        public string NameOfUser { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Addresses = new List<string>();
    }
}
