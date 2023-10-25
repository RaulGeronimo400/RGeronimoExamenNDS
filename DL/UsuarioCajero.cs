using System;
using System.Collections.Generic;

namespace DL;

public partial class UsuarioCajero
{
    public int IdUsuarioCajero { get; set; }

    public int? NoCuenta { get; set; }

    public int? IdCajero { get; set; }

    public int? CantidadRetiro { get; set; }

    public int? CantidadDeposito { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Cajero? IdCajeroNavigation { get; set; }

    public virtual Usuario? NoCuentaNavigation { get; set; }
}
