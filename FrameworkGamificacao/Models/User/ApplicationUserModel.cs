namespace FrameworkGamificacao.Models.User
{
    public class ApplicationUserModel
    {
        private UserCredentialModel Credential { get; set; } = new();

        private string Name { get; set; } = string.Empty;

        private string Email { get; set; } = string.Empty;

        private UserConfigurationModel Configuration { get; set; } = new();

    }
}
