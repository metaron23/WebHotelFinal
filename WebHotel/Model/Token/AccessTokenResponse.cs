namespace WebHotel.Model.Token
{
    public class AccessTokenResponse
    {
        public string? TokenString { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
