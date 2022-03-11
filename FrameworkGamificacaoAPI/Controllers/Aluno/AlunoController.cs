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
	public class AlunoController : ControllerBase
	{
		private readonly IConfiguration Configuration;

		public AlunoController(IConfiguration config)
		{
			Configuration = config;
		}

		[HttpGet]
		[Route("getAlunos")]
		public IEnumerable<Aluno> GetAll()
		{
			List<Aluno> alunos = new();
			using (SqlConnection connection = new(Configuration.GetConnectionString("AzureConnection")))
			{
				connection.Open();
				alunos = new AlunoDAO(connection).FindAll(new AlunoFiltro());
				connection.Close();
			}
			return alunos;
		}
	}
}
