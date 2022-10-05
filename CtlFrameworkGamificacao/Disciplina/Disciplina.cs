using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class Disciplina : IBaseEntity
	{
		public long ID { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime DateUpdate { get; set; }
		public string Nome { get; set; }
		public int Ano { get; set; }
		public int Semestre { get; set; }
		public Professor Professor { get; set; }
		public List<Aluno> Alunos { get; set; }
		public Disciplina(long iD,
						  DateTime dateCreation,
						  DateTime dateUpdate,
						  string nome,
						  int ano,
						  int semestre,
						  Professor professor,
						  List<Aluno> alunos)
		{
			ID = iD;
			DateCreation = dateCreation;
			DateUpdate = dateUpdate;
			Nome = nome;
			Ano = ano;
			Semestre = semestre;
			Professor = professor;
			Alunos = alunos;
		}
	}
}
