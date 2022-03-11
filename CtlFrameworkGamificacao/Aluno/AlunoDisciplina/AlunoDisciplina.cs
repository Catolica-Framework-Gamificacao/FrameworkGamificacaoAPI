using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class AlunoDisciplina
	{
		public Disciplina Disciplina { get; set; }
		public string UsuarioAluno { get; set; }
		public Decimal Pontos { get; set; }
		public AlunoDisciplina(Disciplina disciplina, string usuarioAluno, Decimal pontos)
		{
			Disciplina = disciplina;
			UsuarioAluno = usuarioAluno;
			Pontos = pontos;
		}
	}
}
