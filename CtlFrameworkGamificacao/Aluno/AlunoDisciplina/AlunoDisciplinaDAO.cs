using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class AlunoDisciplinaDAO : DAO<AlunoFiltro,AlunoDisciplina>
	{
		public AlunoDisciplinaDAO(SqlConnection connection) : base(connection)
		{
		}

		public override string GetSqlSelect(AlunoFiltro filtro)
		{
			var strSQL = $@"SELECT DA.codDisciplina
								  ,DC.nomeDisciplina
								  ,DA.usuarioAluno
								  ,DA.pontos
							FROM CtlCadAlunoDisciplina DA
							LEFT JOIN CtlCadDisciplina DC
							ON DC.codDisciplina = DA.codDisciplina
							WHERE 1=1";
			if (filtro.CodDisciplina.HasValue)
			{
				strSQL += $" AND DA.codDisciplina = {filtro.CodDisciplina}";
			}
			if (!string.IsNullOrEmpty(filtro.UsuarioAluno))
			{
				strSQL += $" AND DA.usuarioAluno= '{filtro.UsuarioAluno}'";
			}
			return strSQL;
		}
		internal override AlunoDisciplina LoadObject(IDataReader dr)
		{
			return new AlunoDisciplina(new Disciplina(true, Convert.ToInt32(dr["codDisciplina"]), Convert.ToString(dr["nomeDisciplina"]))
									 ,Convert.ToString(dr["usuarioAluno"])
									 ,Convert.ToDecimal(dr["pontos"]));
		}

		public override void Save(AlunoDisciplina obj)
		{
			throw new NotImplementedException();
		}

		public override void Delete(AlunoDisciplina obj)
		{
			throw new NotImplementedException();
		}

		public override void SaveTransaction(AlunoDisciplina obj, SqlTransaction tr)
		{
			string strSQL = @"INSERT INTO CtlCadAlunoDisciplina(codDisciplina,usuarioAluno,pontos) VALUES(@codDisciplina,@usuarioAluno,@pontos)";
			SqlCommand comando = new(strSQL, Connection,tr);
			comando.Parameters.Add(new SqlParameter("@codDisciplina", obj.Disciplina.CodDisciplina));
			comando.Parameters.Add(new SqlParameter("@usuarioAluno", obj.UsuarioAluno));
			comando.Parameters.Add(new SqlParameter("@pontos", obj.Pontos));
			comando.ExecuteNonQuery();
		}

		public override void DeleteTransaction(AlunoDisciplina obj, SqlTransaction tr)
		{
			string strSQL = "DELETE FROM CtlCadAlunoDisciplina WHERE usuarioAluno=@usuarioAluno";
			SqlCommand comando = new(strSQL, Connection, tr);
			comando.Parameters.Add(new SqlParameter("@usuarioAluno", obj.UsuarioAluno));
			comando.ExecuteNonQuery();
		}
	}
}
