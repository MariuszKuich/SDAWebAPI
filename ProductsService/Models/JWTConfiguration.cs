namespace ProductsOrdersService.Models
{
    public class JWTConfiguration
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string ValidAudience { get; set; }
        public int TokenExpirationTime { get; set; }
    }
}
