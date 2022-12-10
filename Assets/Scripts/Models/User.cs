namespace Assets.Models
{
    internal class User
    {
        public string display_name { get; set; }
        
        public PremiumState premiumState { get; set; }
    }

    internal enum PremiumState
    {
        NotConfirmed,
        Premium,
        Free
    }
}