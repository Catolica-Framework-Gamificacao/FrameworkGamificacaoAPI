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
		public string UsuarioAluno { get; set; }
		public string NomeAluno { get; set; }
		public string EmailAluno { get; set; }
		public List<AlunoDisciplina> Disciplinas { get; set; }
		public bool ExibirNome { get; set; }
		public Aluno(bool existe, int ra,string usuarioAluno, string nomeAluno,string emailAluno, List<AlunoDisciplina> disciplinas, bool exibirNome)
		{
			Existe = existe;
			RA = ra;
			NomeAluno = nomeAluno;
			UsuarioAluno = usuarioAluno;
			EmailAluno = emailAluno;
			Disciplinas = disciplinas;
			ExibirNome = exibirNome;
		}
	}
}
