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
			using (IDbConnection connection = new SqlConnection(Configuration.GetConnectionString("AzureConnection")))
			{
				connection.Open();
				disciplinas = new DisciplinaDAO(connection).FindAll(new DisciplinaFiltro());
				connection.Close();
			}
			return disciplinas;
		}
	}
}
