namespace Ludus.Models.User
{
    public class ApplicationUserModel
    {
        public UserCredentialModel Credential { get; set; } = new();

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public UserConfigurationModel Configuration { get; set; } = new();

    }
}
