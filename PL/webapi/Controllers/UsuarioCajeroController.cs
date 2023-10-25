using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioCajeroController : ControllerBase
    {
        [EnableCors("API")]
        [HttpPost]
        public IActionResult Movimiento([FromBody] BL.UsuarioCajero usuarioCajero)
        {
            if (usuarioCajero.CantidadRetiro != 0)
            {
                BL.Result result = BL.UsuarioCajero.Retiro(usuarioCajero.Usuario.NoCuenta, usuarioCajero.CantidadRetiro);
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
            else
            {
                BL.Result result = BL.UsuarioCajero.Deposito(usuarioCajero.Usuario.NoCuenta, usuarioCajero.CantidadDeposito);
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [EnableCors("API")]
        [HttpGet("{NoCuenta}")]
        public IActionResult Detalles(int NoCuenta)
        {
            BL.Result result = BL.UsuarioCajero.Detalles(NoCuenta);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
    }
}