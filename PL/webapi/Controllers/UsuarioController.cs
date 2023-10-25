using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

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
                HttpContext.Session.SetString("NoCuenta", usuario.NoCuenta.ToString());//Crear sesion

               
                return Ok(result.Object);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}