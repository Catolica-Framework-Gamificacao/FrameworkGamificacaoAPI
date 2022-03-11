using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameworkGamificacaoClasses;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FrameworkGamificacaoAPI
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class DisciplinaController : ControllerBase
	{
		private readonly IConfiguration Configuration;

		public DisciplinaController(IConfiguration config)
		{
			Configuration = config;
		}

		[HttpGet]
		[Route("getDisciplinas")]
		public IEnumerable<Disciplina> GetAll()
		{
			List<Disciplina> disciplinas = new();
			using (SqlConnection connection = new(Configuration.GetConnectionString("AzureConnection")))
			{
				connection.Open();
				disciplinas = new DisciplinaDAO(connection).FindAll(new DisciplinaFiltro());
				connection.Close();
			}
			return disciplinas;
		}

		[HttpPost]
		[Route("getPontosDisciplina")]
		public IEnumerable<AlunoDisciplina> GetPontosDisciplina(int codDisciplina)
		{
			if (codDisciplina == 0) throw new ArgumentNullException("Disciplina");
			List<AlunoDisciplina> disciplinas = new();
			using (SqlConnection connection = new(Configuration.GetConnectionString("AzureConnection")))
			{
				connection.Open();
				disciplinas = new AlunoDisciplinaDAO(connection).FindAll(new AlunoFiltro { CodDisciplina = codDisciplina});
				connection.Close();
			}
			return disciplinas;
		}

		[HttpPut]
		[Route("saveDisciplina")]
		public Disciplina Save(Disciplina disciplina)
		{
			ValidateDisciplina(disciplina);
			using SqlConnection connection = new(Configuration.GetConnectionString("AzureConnection"));
			{
				connection.Open();
				var disciplinaDAO = new DisciplinaDAO(connection);
				disciplinaDAO.Save(disciplina);
				connection.Close();
			}
			return disciplina;
		}

		[HttpDelete]
		[Route("deleteDisciplina")]
		public bool Delete(Disciplina disciplina)
		{
			ValidateDisciplina(disciplina);
			using SqlConnection connection = new(Configuration.GetConnectionString("AzureConnection"));
			{
				connection.Open();
				var disciplinaDAO = new DisciplinaDAO(connection);
				disciplinaDAO.Delete(disciplina);
				connection.Close();
			}
			return true;
		}

		private static void ValidateDisciplina(Disciplina disciplina)
		{
			if (disciplina == null) throw new ArgumentNullException(disciplina.ToString());
			if (disciplina.Existe && disciplina.CodDisciplina == 0) throw new ArgumentNullException(disciplina.ToString());
		}
	}
}
