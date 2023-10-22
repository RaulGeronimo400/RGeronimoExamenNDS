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

        public Result Retiro(int NoCuenta, int CantidadRetiro)
        {
            Result result = new Result();
            try
            {
                using(DL.RgeronimoExamenNdsContext context = new DL.RgeronimoExamenNdsContext())
                {
                    var Cajero = (from saldoLQ in context.Cajeros 
                                       select saldoLQ.Saldo);
                    int SaldoCajero = Convert.ToInt32(Cajero);
                    if (CantidadRetiro <= SaldoCajero)
                    {
                        //Retiro de dinero
                        DL.UsuarioCajero usuarioCajero = new DL.UsuarioCajero();
                        usuarioCajero.CantidadRetiro = CantidadRetiro;
                        usuarioCajero.NoCuenta = NoCuenta;
                        usuarioCajero.IdCajero = 1;
                        context.UsuarioCajeros.Add(usuarioCajero);
                        context.SaveChanges();

                        //Actualizar saldo de la cuenta
                        var saldo = (from usuarioLQ in context.Usuarios
                                     where usuarioLQ.NoCuenta == NoCuenta
                                     select usuarioLQ).SingleOrDefault();

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
