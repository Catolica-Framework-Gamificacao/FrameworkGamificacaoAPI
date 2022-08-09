using Microsoft.AspNetCore.Components.Web;

namespace FrameworkGamificacaoAPI.Models.Usuario;

public class UsuarioModel
{
    public int Id;

    public string Ra { get; set; }

    public string Name { get; set; }

    public bool ShowOnRanking { get; set; }
    
    public int Points { get; set; }
    
    public string Token { get; set; }
    
    public UsuarioModel(int id, string ra, string name, bool showOnRanking, int points, string token)
    {
        this.Id = id;
        this.Ra = ra;
        this.Name = name;
        this.ShowOnRanking = showOnRanking;
        this.Points = points;
        this.Token = token;
    }
    
    public UsuarioModel(){}
}