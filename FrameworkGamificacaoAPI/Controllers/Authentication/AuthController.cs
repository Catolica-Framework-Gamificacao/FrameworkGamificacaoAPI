using System.Data.SqlClient;
using FrameworkGamificacaoAPI.Models.Authentication;
using FrameworkGamificacaoAPI.Models.Usuario;
using FrameworkGamificacaoClasses.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace FrameworkGamificacaoAPI.Controllers.Authentication
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration config)
        {
            _configuration = config;
        }
        
        [HttpPost]
        public IActionResult Authenticate(Credential credential)
        {
            using (SqlConnection connection = new(_configuration.GetConnectionString("AzureConnection")))
            {
                //connection.Open();
                Console.WriteLine(credential.ToString());
                //connection.Close();
                return Ok(new UsuarioModel());
            }
           return BadRequest("Invalid credentials"); ;
        }
    }
}