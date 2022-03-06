using Microsoft.AspNetCore.Mvc;
using Ludus.Models;

namespace Ludus.Controllers
{
    [ApiController]
    [Route("ranking")]
    public class RankingController : Controller
    {

        private static readonly string[] Disciplinas = new[] { "POO", "Web Design", "Segurança da Informação", "IOT", "IA", "Data mining" };

        [HttpGet]
        public List<PosicaoRankingModel> GetAll()
        {

            //Depois de buscar do banco, precisa desviar do ranking os alunos que terão o campo Exibir = false

            List<PosicaoRankingModel> ranking = new();

            for (int index = 0; index < 6; index++)
            {
                DisciplinaModel disciplina = new();
                disciplina.Nome = Disciplinas[index];
                disciplina.UUID = Guid.NewGuid().ToString();

                PosicaoRankingModel posicao = new()
                {
                    Pontuacao = index + 0.3,
                    Posicao = (index + 1),
                    Disciplina = disciplina
                };

                ranking.Add(posicao);
            }

            return ranking;
        }

        [HttpGet("{uuid}")]
        public List<PosicaoRankingModel> GetByDisciplina(String UUID)
        {
            List<PosicaoRankingModel> ranking = GetAll(); //Temporário, posteriormente já trazer feito do banco sem precisar manipular em memória

            ranking = ranking.Where(posicao => posicao.Disciplina.UUID == UUID).ToList();

            return ranking;
        }

    }
}
