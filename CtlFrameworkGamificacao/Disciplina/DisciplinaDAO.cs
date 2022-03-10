using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkGamificacaoClasses
{
	public class DisciplinaDAO : DAO<DisciplinaFiltro,Disciplina>
	{
		public DisciplinaDAO(IDbConnection connection) : base(connection)
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
			throw new NotImplementedException();
		}

		public override void Delete(Disciplina obj)
		{
			throw new NotImplementedException();
		}
	}
}
