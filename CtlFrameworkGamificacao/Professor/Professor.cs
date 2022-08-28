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
		public string NomeProfessor { get; set; }
		public string Usuario { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public string Token { get; set; }

		public Professor(bool existe, string nomeProfessor, string usuario, string email, string senha, string token)
		{
			Existe = existe;
			NomeProfessor = nomeProfessor;
			Usuario = usuario;
			Email = email;
			Senha = senha;
			Token = token;
		}

		public Professor(bool existe, string nomeProfessor, string usuario, string email, string senha)
		{
			Existe = existe;
			NomeProfessor = nomeProfessor;
			Usuario = usuario;
			Email = email;
			Senha = senha;
			Token = null;
		}
	}
}
