using Microsoft.AspNetCore.Mvc;
using FrameworkGamificacaoClasses;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FrameworkGamificacaoAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProfessorController(IConfiguration config)
        {
            _configuration = config;
        }

        //[HttpGet]
        //[Route("getProfessores")]
        //public IEnumerable<Professor> GetAll()
        //{
        //	List<Professor> professores = new();
        //	using (SqlConnection connection = new(_configuration.GetConnectionString("AzureConnection")))
        //	{
        //		connection.Open();
        //		professores =  new ProfessorDAO(connection).FindAll(new ProfessorFiltro());
        //		connection.Close();
        //	}
        //	return professores;
        //}

        [HttpPost]
        [Route("loginProfessor")]
        public IActionResult LoginProfessor(ProfessorFiltro login)
        {
            Professor professor;
            using (SqlConnection connection = new(_configuration.GetConnectionString("AzureConnection")))
            {
                connection.Open();
                professor = new ProfessorDAO(connection).FindOne(login);
                connection.Close();
                if (professor != null)
                {
                    return Ok(CreateToken(professor));
                }
            }
            return BadRequest("Invalid credentials"); ;
        }

        private string CreateToken(Professor professor)
        {
            var claims = new[] {
                        new Claim(ClaimTypes.NameIdentifier, professor.Usuario),
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
