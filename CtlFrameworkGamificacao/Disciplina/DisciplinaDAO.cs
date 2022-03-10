using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrameworkGamificacaoClasses
{
	public class DisciplinaDAO : DAO<DisciplinaFiltro,Disciplina>
	{
		public DisciplinaDAO(SqlConnection connection) : base(connection)
		{
		}

		public override string GetSqlSelect(DisciplinaFiltro filtro)
		{
			Validate(filtro);

			var strSQL = $@"SELECT DC.codDisciplina
								  ,DC.nomeDisciplina
							FROM CtlCadDisciplina DC
							WHERE 1=1";
			if(filtro.CodDisciplina > 0)
			{
				strSQL += $" AND DC.codDisciplina = {filtro.CodDisciplina}";
			}
			return strSQL;	
		}

		internal override Disciplina LoadObject(IDataReader dr)
		{
			return new Disciplina(true
								 ,(int)dr["codDisciplina"]
								 ,(string)dr["nomeDisciplina"]);
		}

		public override void Save(Disciplina obj)
		{
			string strSQL;
			if (!obj.Existe)
			{
				strSQL = @"INSERT INTO CtlCadDisciplina(nomeDisciplina) VALUES(@nomeDisciplina)
						   Select Scope_Identity()";
				SqlCommand comando = new(strSQL, Connection);
				comando.Parameters.Add(new SqlParameter("@nomeDisciplina", obj.NomeDisciplina));
				obj.CodDisciplina = Convert.ToInt32(comando.ExecuteScalar());
				obj.Existe = true;
			}
			else
			{
				strSQL = "UPDATE CtlCadDisciplina set nomeDisciplina=@nomeDisciplina WHERE codDisciplina=@codDisciplina";
				SqlCommand comando = new(strSQL, Connection);
				comando.Parameters.Add(new SqlParameter("@codDisciplina", obj.CodDisciplina));
				comando.Parameters.Add(new SqlParameter("@nomeDisciplina", obj.NomeDisciplina));
				comando.ExecuteScalar();
			}
		}

		public override void Delete(Disciplina obj)
		{
			throw new NotImplementedException();
		}
	}
}
