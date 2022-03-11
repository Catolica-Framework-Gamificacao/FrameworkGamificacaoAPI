using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class AlunoDAO : DAO<AlunoFiltro, Aluno>
	{
		public AlunoDAO(SqlConnection connection) : base(connection)
		{
		}

		public override string GetSqlSelect(AlunoFiltro filtro)
		{
			var strSQL = $@"SELECT AU.usuarioAluno
								  ,AU.RA
								  ,AU.nomeAluno
								  ,AU.emailAluno
								  ,AU.exibirNome
							FROM CtlCadAluno AU
							WHERE 1=1";
			if (filtro.RA.HasValue)
			{
				strSQL += $" AND AU.RA = {filtro.RA}";
			}
			if (!string.IsNullOrEmpty(filtro.UsuarioAluno))
			{
				strSQL += $" AND AU.usuarioAluno ={filtro.UsuarioAluno}";
			}
			if (filtro.CodDisciplina.HasValue)
			{
				strSQL += $" AND (SELECT COUNT(codDisciplina) FROM CtlCadAlunoDisciplina DC WHERE DC.usuarioAluno = AU.usuarioAluno AND DC.codDisciplina = {filtro.CodDisciplina}) > 0";
			}
			return strSQL;
		}

		public override List<Aluno> FindAll(AlunoFiltro filtro)
		{
			List<Aluno> alunos = base.FindAll(filtro);
			List<AlunoDisciplina> alunoDisciplinas = new AlunoDisciplinaDAO(Connection).FindAll(filtro);
			foreach (Aluno aluno in alunos)
			{
				aluno.Disciplinas = RetornaDisciplinasAluno(aluno, alunoDisciplinas);
			}
			return alunos;
		}

		public override Aluno FindOne(AlunoFiltro filtro)
		{
			Aluno aluno = base.FindOne(filtro);
			List<AlunoDisciplina> alunoDisciplinas = new AlunoDisciplinaDAO(Connection).FindAll(filtro);
			aluno.Disciplinas = RetornaDisciplinasAluno(aluno, alunoDisciplinas);
			return aluno;
		}

		public static List<AlunoDisciplina> RetornaDisciplinasAluno(Aluno aluno, List<AlunoDisciplina> alunoDisciplinas)
		{
			return alunoDisciplinas.Where(disciplina => disciplina.UsuarioAluno == aluno.UsuarioAluno).ToList();
		}

		internal override Aluno LoadObject(IDataReader dr)
		{
			return new Aluno(true
							, Convert.ToInt32(dr["RA"])
							, Convert.ToString(dr["usuarioAluno"])
							, Convert.ToString(dr["nomeAluno"])
							, Convert.ToString(dr["emailAluno"])
							, new List<AlunoDisciplina>()
							, Convert.ToBoolean(dr["exibirNome"]));
		}

		public override void Save(Aluno obj)
		{
			throw new NotImplementedException();
		}

		public override void Delete(Aluno obj)
		{
			throw new NotImplementedException();
		}
	}
}
