using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class ProfessorDAO : DAO<ProfessorFiltro,Professor>
	{
		public ProfessorDAO(SqlConnection connection): base(connection)
		{
		}

		public override string GetSqlSelect(ProfessorFiltro filtro)
		{
			Validate(filtro);

			var strSQL = $@"SELECT PF.codProfessor
								  ,PF.nomeProfessor
								  ,PF.usuario
								  ,PF.email
								  ,PF.senha
							FROM CtlCadProfessor PF
							WHERE 1=1";
			if (!string.IsNullOrEmpty(filtro.Usuario))
			{
				strSQL += $" AND PF.usuario = '{filtro.Usuario}'";
			}
			if (!string.IsNullOrEmpty(filtro.Email))
			{
				strSQL += $" AND PF.email = '{filtro.Email}'";
			}
			if (!string.IsNullOrEmpty(filtro.Senha))
			{
				strSQL += $" AND PF.senha = '{filtro.Senha}'";
			}

			return strSQL;
		}

		internal override Professor LoadObject(IDataReader dr)
		{
			return new Professor(true
								, Convert.ToInt32(dr["codProfessor"])
								, Convert.ToString(dr["nomeProfessor"])
								, Convert.ToString(dr["usuario"])
								, Convert.ToString(dr["email"])
								, Convert.ToString(dr["senha"]));
		}

		public override void Delete(Professor obj)
		{
			throw new NotImplementedException();
		}

		public override void Save(Professor obj)
		{
			throw new NotImplementedException();
		}

		public override void SaveTransaction(Professor obj, SqlTransaction tr)
		{
			throw new NotImplementedException();
		}

		public override void DeleteTransaction(Professor obj, SqlTransaction tr)
		{
			throw new NotImplementedException();
		}
	}
}