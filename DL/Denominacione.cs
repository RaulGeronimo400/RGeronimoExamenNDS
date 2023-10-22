using System;
using System.Collections.Generic;

namespace DL;

public partial class Denominacione
{
    public int IdBillete { get; set; }

    public int? Denominacion { get; set; }

    public int? Cantidad { get; set; }

    public int? IdCajero { get; set; }

    public virtual Cajero? IdCajeroNavigation { get; set; }
}
