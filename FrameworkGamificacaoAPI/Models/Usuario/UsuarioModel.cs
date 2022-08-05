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
    
    public UsuarioModel(int id, string ra, string name, bool showOnRanking, int points, string token)
    {
        this.id = id;
        RA = ra;
        Name = name;
        ShowOnRanking = showOnRanking;
        Points = points;
        Token = token;
    }
    
    public UsuarioModel(){}
}