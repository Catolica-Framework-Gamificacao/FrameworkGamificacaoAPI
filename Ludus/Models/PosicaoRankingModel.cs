namespace Ludus.Models
{
    public class PosicaoRankingModel
    {

        public long Posicao { get; set; } = 0;

        public string Aluno { get; set; } = string.Empty;

        public double Pontuacao { get; set; } = 0;

        public DisciplinaModel Disciplina { get; set; } = new();

    }
}
