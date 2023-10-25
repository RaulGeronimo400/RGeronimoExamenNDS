using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public int NoCuenta { get; set; }
        public int NIP { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Saldo { get; set; }

        public static Result Login(Usuario usuario)
        {
            Result result = new Result();

            try
            {
                using (DL.RgeronimoExamenNdsContext context = new DL.RgeronimoExamenNdsContext())
                {
                    var query = (from usuarioLQ in context.Usuarios
                                 where usuarioLQ.Nip == usuario.NIP
                                 && usuarioLQ.NoCuenta == usuario.NoCuenta
                                 select usuarioLQ).Single();
                    if (query != null)
                    {
                        usuario.NoCuenta = query.NoCuenta;
                        usuario.NIP = query.Nip.Value;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Saldo = query.Saldo.Value;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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
