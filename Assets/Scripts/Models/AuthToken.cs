namespace Assets.Models
{
    internal class AuthToken
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }

        public string scope { get; set; }

        public string refresh_token { get; set; }
        

        public override string ToString()
        {
            return $"Access_Token: {access_token}; TokenType: {token_type}; ExpiresIn: {expires_in}";
        }
    }
}