using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [EnableCors("API")]
        [HttpPost]
        public IActionResult Post([FromBody] BL.Usuario usuario)
        {
            BL.Result result = BL.Usuario.Login(usuario);
            if (result.Correct)
            {
                return Ok(usuario);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [EnableCors("API")]
        [HttpGet("{NoCuenta}")]
        public IActionResult Get(int NoCuenta)
        {
            BL.Result result = BL.Usuario.GetUser(NoCuenta);
            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

    }
}