using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int NoCuenta { get; set; }

    public int? Nip { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public int? Saldo { get; set; }

    public virtual ICollection<UsuarioCajero> UsuarioCajeros { get; set; } = new List<UsuarioCajero>();
}
