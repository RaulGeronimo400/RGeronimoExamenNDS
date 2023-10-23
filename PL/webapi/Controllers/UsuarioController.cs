using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [EnableCors("API")]
        [HttpGet("{NIP}")]
        public IActionResult Login(int NIP)
        {
            BL.Result result = BL.Usuario.Login(NIP);
            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
