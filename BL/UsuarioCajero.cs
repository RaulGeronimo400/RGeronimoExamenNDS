using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioCajero
    {
        public int IdUsuarioCajero { get; set; }
        public int NoCuenta { get; set; }
        public int IdCajero { get; set; }
        public int CantidadRetiro { get; set; }
        public int CantidadDeposito { get; set; }
        public List<object> Movimientos { get; set; }
    }
}
