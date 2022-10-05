using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class Tarefa : IBaseEntity
	{
		public long ID { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime DateUpdate { get; set; }
		public Disciplina Disciplina { get; set; }
		public string Nome { get; set; }
		public List<LancamentoTarefa> Lancamentos { get; set; }

		public Tarefa(long iD,
				      DateTime dateCreation,
					  DateTime dateUpdate,
					  Disciplina disciplina,
					  string nome,
					  List<LancamentoTarefa> lancamentos)
		{
			ID = iD;
			DateCreation = dateCreation;
			DateUpdate = dateUpdate;
			Disciplina = disciplina;
			Nome = nome;
			Lancamentos = lancamentos;
		}
	}
}
