using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class Professor : IBaseEntity, IUsuario
	{
		public long ID { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime DateUpdate { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public UserRole Role { get; set; }
		public UserStatus Situacao { get; set; }
		public string Avatar { get; set; }
		public List<Disciplina> Disciplinas { get; set; }
		public Professor(long iD,
						 DateTime dateCreation,
						 DateTime dateUpdate,
						 string nome,
						 string email,
						 string senha,
						 UserRole role,
						 UserStatus status,
						 string avatar,
						 List<Disciplina> disciplinas)
		{
			ID = iD;
			DateCreation = dateCreation;
			DateUpdate = dateUpdate;
			Nome = nome;
			Email = email;
			Senha = senha;
			Role = role;
			Situacao = status;
			Avatar = avatar;
			Disciplinas = disciplinas;
		}
	}
}
