using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class Professor
	{
		public bool Existe { get; set; }
		public double CodProfessor { get; set; }
		public string NomeProfessor { get; set; }
		public string Usuario { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }

		public Professor(bool existe, double codProfessor,string nomeProfessor, string usuario, string email, string senha)
		{
			Existe = existe;
			CodProfessor = codProfessor;
			NomeProfessor = nomeProfessor;
			Usuario = usuario;
			Email = email;
			Senha = senha;
		}
	}
}
