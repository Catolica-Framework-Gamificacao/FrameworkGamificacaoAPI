using Microsoft.AspNetCore.Mvc;
using Ludus.Models;

namespace Ludus.Controllers
{
    [ApiController]
    [Route("aluno")]
    public class AlunoController : Controller
    {

        [HttpGet]
        public List<AlunoModel> GetAll()
        {
            List<AlunoModel> alunos = new();

            for (int index = 0; index < 6; index++)
            {
                AlunoModel aluno = new()
                {
                    RA = index.ToString()
                };

                alunos.Add(aluno);
            }

            return alunos;
        }

        [HttpGet("{RA}")]
        public AlunoModel GetByRA(string RA) {
            AlunoModel aluno = new();
            aluno.RA = RA;
            return aluno;
        }

        [HttpPost]
        public AlunoModel Create(AlunoModel body)
        {
            AlunoModel aluno = new(body.RA, body.Name);
            return aluno;
        }

    }
}
