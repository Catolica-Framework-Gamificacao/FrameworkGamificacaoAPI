using Microsoft.AspNetCore.Components.Web;

namespace FrameworkGamificacaoAPI.Models.Usuario;

public class UsuarioModel
{
    public int id;
    
    public string RA { get; set; }

    public string Name { get; set; }

    public bool ShowOnRanking { get; set; }
    
    public int Points { get; set; }
    
    public string Token { get; set; }
}