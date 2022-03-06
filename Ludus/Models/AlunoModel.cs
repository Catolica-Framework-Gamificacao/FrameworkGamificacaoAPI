using Ludus.Models.User;

namespace Ludus.Models
{
    public class AlunoModel : ApplicationUserModel
    {

        public string RA { get; set; } = string.Empty;

        public int Pontos { get; set; }  = 0;

        public bool Exibir { get; set; } = false;

        public List<DisciplinaModel> Disciplinas { get; set; } = new List<DisciplinaModel>();

        public AlunoModel() {}

        public AlunoModel(string RA, string nome)
        {
            this.RA = RA;
            this.Name = nome;
        }

    }
}
