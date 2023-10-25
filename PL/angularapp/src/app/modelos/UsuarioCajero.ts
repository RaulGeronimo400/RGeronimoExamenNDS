import { Cajero } from "./Cajero";
import { Usuario } from "./Usuario";

export interface UsuarioCajero {
  idUsuarioCajero?: number;
  usuario?: Usuario;
  cajero?: Cajero;
  cantidadRetiro?: number;
  cantidadDeposito?: number;
}
