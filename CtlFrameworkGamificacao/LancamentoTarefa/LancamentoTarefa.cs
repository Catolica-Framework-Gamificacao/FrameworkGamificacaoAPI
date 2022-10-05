using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class LancamentoTarefa : IBaseEntity
	{
		public long ID { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime DateUpdate { get; set; }
		public Tarefa Tarefa { get; set; }
		public Aluno Aluno { get; set; }
		public double Pontuacao { get; set; }

		public LancamentoTarefa(long iD, DateTime dateCreation, DateTime dateUpdate, Tarefa tarefa, Aluno aluno, double pontuacao)
		{
			ID = iD;
			DateCreation = dateCreation;
			DateUpdate = dateUpdate;
			Tarefa = tarefa;
			Aluno = aluno;
			Pontuacao = pontuacao;
		}
	}
}
