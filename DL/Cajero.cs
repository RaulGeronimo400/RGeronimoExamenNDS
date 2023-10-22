using System;
using System.Collections.Generic;

namespace DL;

public partial class Cajero
{
    public int IdCajero { get; set; }

    public int? Saldo { get; set; }

    public virtual ICollection<Denominacione> Denominaciones { get; set; } = new List<Denominacione>();

    public virtual ICollection<UsuarioCajero> UsuarioCajeros { get; set; } = new List<UsuarioCajero>();
}
