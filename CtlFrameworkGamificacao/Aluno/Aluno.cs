using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class Aluno
	{
		public bool Existe { get; set; }
		public int RA { get; set; }
		public string NomeAluno { get; set; }
		public List<Disciplina> Disciplinas { get; set; }
		public bool ExibirNome { get; set; }
		public Dictionary<Disciplina,decimal> PontosDisciplina { get; set; }
		public Aluno(bool existe, int rA, string nomeAluno, List<Disciplina> disciplinas, bool exibirNome, Dictionary<Disciplina, decimal> pontosDisciplina)
		{
			Existe = existe;
			RA = rA;
			NomeAluno = nomeAluno;
			Disciplinas = disciplinas;
			ExibirNome = exibirNome;
			PontosDisciplina = pontosDisciplina;
		}
	}
}
