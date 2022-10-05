﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class AlunoDisciplina : IBaseEntity
	{
		public long ID { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime DateUpdate { get; set; }
		public Disciplina Disciplina { get; set; }
		public Aluno Aluno { get; set; }
		public double Pontuacao { get; set; }
		public AlunoDisciplina(long iD, DateTime dateCreation, DateTime dateUpdate, Disciplina disciplina, Aluno aluno, double pontuacao)
		{
			ID = iD;
			DateCreation = dateCreation;
			DateUpdate = dateUpdate;
			Disciplina = disciplina;
			Aluno = aluno;
			Pontuacao = pontuacao;
		}
	}
}
