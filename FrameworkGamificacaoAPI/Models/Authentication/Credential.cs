using System.Text.Json.Serialization;

namespace FrameworkGamificacaoAPI.Models.Authentication;

public class Credential
{
    [JsonPropertyName("login")]
    public string Login { get; set; }
    
    [JsonPropertyName("password")]
    public string Password { get; set; }
}