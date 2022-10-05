using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public interface IUsuario
	{
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public UserRole Role { get; set; }
		public string Avatar { get; set; }
		public UserStatus Situacao { get; set; }
	}
}
