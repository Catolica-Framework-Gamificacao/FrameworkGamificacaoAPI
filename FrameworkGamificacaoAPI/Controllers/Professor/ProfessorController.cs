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
	public class ProfessorController : ControllerBase
	{
		private readonly IConfiguration Configuration;

		public ProfessorController(IConfiguration config)
		{
			Configuration = config;
		}

		[HttpGet]
		[Route("getProfessores")]
		public IEnumerable<Professor> GetAll()
		{
			List<Professor> professores = new();
			using (SqlConnection connection = new(Configuration.GetConnectionString("AzureConnection")))
			{
				connection.Open();
				professores =  new ProfessorDAO(connection).FindAll(new ProfessorFiltro());
				connection.Close();
			}
			return professores;
		}
	}
}
