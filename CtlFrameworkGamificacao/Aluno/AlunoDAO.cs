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

		public override void SaveTransaction(Aluno obj, SqlTransaction transaction)
		{
			string strSQL;
			if (!obj.Existe)
			{
				strSQL = @"INSERT INTO CtlCadAluno(usuarioAluno,RA,nomeAluno,emailAluno,exibirNome)
						   VALUES(@usuarioAluno,@RA,@nomeAluno,@emailAluno,@exibirNome) ";
				SqlCommand comando = new(strSQL, Connection, transaction);
				comando.Parameters.Add(new SqlParameter("@usuarioAluno", obj.UsuarioAluno));
				comando.Parameters.Add(new SqlParameter("@RA", obj.RA));
				comando.Parameters.Add(new SqlParameter("@nomeAluno", obj.NomeAluno));
				comando.Parameters.Add(new SqlParameter("@emailAluno", obj.EmailAluno));
				comando.Parameters.Add(new SqlParameter("@exibirNome", obj.ExibirNome));
				comando.ExecuteScalar();
				obj.Existe = true;

				AlunoDisciplinaDAO alunoDisciplinaDAO = new(Connection);
				alunoDisciplinaDAO.DeleteTransaction(new AlunoDisciplina(null, obj.UsuarioAluno, 0),transaction);
				foreach (AlunoDisciplina disciplina in obj.Disciplinas)
				{
					alunoDisciplinaDAO.SaveTransaction(disciplina, transaction);
				}
			}
			else
			{
				strSQL = @"UPDATE CtlCadAluno SET RA=@RA,nomeAluno=@nomeAluno,emailAluno=@emailAluno,exibirNome=@exibirNome 
						   WHERE usuarioAluno=@usuarioAluno";
				SqlCommand comando = new(strSQL, Connection, transaction);
				comando.Parameters.Add(new SqlParameter("@usuarioAluno", obj.UsuarioAluno));
				comando.Parameters.Add(new SqlParameter("@RA", obj.RA));
				comando.Parameters.Add(new SqlParameter("@nomeAluno", obj.NomeAluno));
				comando.Parameters.Add(new SqlParameter("@emailAluno", obj.EmailAluno));
				comando.Parameters.Add(new SqlParameter("@exibirNome", obj.ExibirNome));
				comando.ExecuteScalar();

				AlunoDisciplinaDAO alunoDisciplinaDAO = new(Connection);
				alunoDisciplinaDAO.DeleteTransaction(new AlunoDisciplina(null, obj.UsuarioAluno, 0), transaction);
				foreach (AlunoDisciplina disciplina in obj.Disciplinas)
				{
					alunoDisciplinaDAO.SaveTransaction(disciplina, transaction);
				}
			}
		}
		public override void DeleteTransaction(Aluno obj,SqlTransaction transaction)
		{
			string strSQL = "DELETE FROM CtlCadAluno WHERE usuarioAluno=@usuarioAluno";
			SqlCommand comando = new(strSQL, Connection, transaction);
			comando.Parameters.Add(new SqlParameter("@usuarioAluno", obj.UsuarioAluno));
			comando.ExecuteNonQuery();

			new AlunoDisciplinaDAO(Connection).DeleteTransaction(new AlunoDisciplina(null, obj.UsuarioAluno, 0),transaction);
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
