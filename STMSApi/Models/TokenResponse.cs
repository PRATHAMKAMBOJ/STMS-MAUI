namespace STMSApi.Models
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime TokenCreationTime { get; set; }
        public User User { get; set; }
    }
}
