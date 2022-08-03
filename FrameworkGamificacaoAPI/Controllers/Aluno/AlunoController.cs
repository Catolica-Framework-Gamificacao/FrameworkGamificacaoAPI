using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using FrameworkGamificacaoClasses;

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

		[HttpPut]
		[Route("saveAluno")]
		public Aluno Save(Aluno aluno)
		{
			ValidateAluno(aluno);
			using SqlConnection connection = new(Configuration.GetConnectionString("AzureConnection"));
			{
				connection.Open();
				SqlTransaction tr = connection.BeginTransaction();
				try
				{
					new AlunoDAO(connection).SaveTransaction(aluno, tr);
					tr.Commit();
				}
				catch (Exception ex)
				{
					tr.Rollback();
					throw new ApplicationException(ex.Message);
				}
				finally
				{
					tr.Dispose();
					connection.Close();
				}
			}
			return aluno;
		}

		[HttpDelete]
		[Route("deleteAluno")]
		public bool Delete(Aluno aluno)
		{
			ValidateAluno(aluno);
			using SqlConnection connection = new(Configuration.GetConnectionString("AzureConnection"));
			{
				connection.Open();
				SqlTransaction tr = connection.BeginTransaction();
				try
				{
					new AlunoDAO(connection).DeleteTransaction(aluno, tr);
					tr.Commit();
				}
				catch (Exception ex)
				{
					tr.Rollback();
					throw new ApplicationException(ex.Message);
				}
				finally
				{
					tr.Dispose();
					connection.Close();
				}
			}
			return true;
		}

		private static void ValidateAluno(Aluno aluno)
		{
			if (aluno == null) throw new ArgumentNullException(aluno!.ToString());
			if (string.IsNullOrEmpty(aluno.UsuarioAluno)) throw new ArgumentNullException(aluno.ToString());
		}
	}
}
