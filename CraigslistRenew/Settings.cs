namespace CraigslistRenew
{
    public class Settings
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string UserAgent { get; private set; }

        public Settings(string email, string password, string userAgent)
        {
            Email = email;
            Password = password;
            UserAgent = userAgent;
        }
    }
}
