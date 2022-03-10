using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public  class Disciplina
	{
		public bool Existe { get; set; }
		public int CodDisciplina { get; set; }
		public string NomeDisciplina { get; set; }
		public Disciplina(bool existe, int codDisciplina, string nomeDisciplina)
		{
			Existe = existe;
			CodDisciplina = codDisciplina;
			NomeDisciplina = nomeDisciplina;
		}
	}
}
