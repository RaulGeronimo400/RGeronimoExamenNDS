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
        public Usuario Usuario { get; set; }
        public Cajero Cajero { get; set; }
        public int CantidadRetiro { get; set; }
        public int CantidadDeposito { get; set; }

        public static Result Retiro(int NoCuenta, int CantidadRetiro)
        {
            Result result = new Result();
            try
            {
                using (DL.RgeronimoExamenNdsContext context = new DL.RgeronimoExamenNdsContext())
                {
                    var Cajero = (from saldoLQ in context.Cajeros
                                  select saldoLQ).SingleOrDefault();

                    int SaldoCajero = Convert.ToInt32(Cajero.Saldo);

                    var query = (from usuarioLQ in context.Usuarios
                                 where usuarioLQ.NoCuenta == NoCuenta
                                 select usuarioLQ).SingleOrDefault();

                    int SaldoUsuario = Convert.ToInt32(query.Saldo);

                    if (CantidadRetiro <= SaldoCajero)
                    {
                        if (CantidadRetiro <= SaldoUsuario)
                        {
                            //Retiro de dinero
                            DL.UsuarioCajero usuarioCajero = new DL.UsuarioCajero();
                            usuarioCajero.CantidadRetiro = CantidadRetiro;
                            usuarioCajero.NoCuenta = NoCuenta;
                            usuarioCajero.IdCajero = 1;
                            context.UsuarioCajeros.Add(usuarioCajero);
                            context.SaveChanges();


                            //Actualizar saldo de la cuenta
                            var saldoLQ = (from usuarioLQ in context.Usuarios
                                           where usuarioLQ.NoCuenta == NoCuenta
                                           select usuarioLQ).SingleOrDefault();

                            DL.Usuario usuario = new DL.Usuario();
                            saldoLQ.Saldo = Convert.ToInt32(saldoLQ.Saldo) - CantidadRetiro;
                            context.SaveChanges();


                            //Actualizar saldo del cajero
                            Cajero.Saldo = SaldoCajero - CantidadRetiro;
                            context.SaveChanges();
                            result.Correct = true;
                        }
                        else
                        {
                            result.ErrorMessage = "El Usuario no cuenta con el saldo suficiente";
                            result.Correct = false;
                        }
                    }
                    else
                    {
                        result.ErrorMessage = "El Cajero no cuenta con el saldo suficiente";
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
        public static Result Deposito(int NoCuenta, int CantidadDeposito)
        {
            Result result = new Result();
            try
            {
                using (DL.RgeronimoExamenNdsContext context = new DL.RgeronimoExamenNdsContext())
                {
                    var Cajero = (from saldoL in context.Cajeros
                                  select saldoL).SingleOrDefault();

                    int SaldoCajero = Convert.ToInt32(Cajero.Saldo);


                    //Retiro de dinero
                    DL.UsuarioCajero usuarioCajero = new DL.UsuarioCajero();
                    usuarioCajero.CantidadDeposito = CantidadDeposito;
                    usuarioCajero.NoCuenta = NoCuenta;
                    usuarioCajero.IdCajero = 1;
                    context.UsuarioCajeros.Add(usuarioCajero);
                    context.SaveChanges();


                    //Actualizar saldo de la cuenta
                    var saldoLQ = (from usuarioLQ in context.Usuarios
                                   where usuarioLQ.NoCuenta == NoCuenta
                                   select usuarioLQ).SingleOrDefault();

                    saldoLQ.Saldo = Convert.ToInt32(saldoLQ.Saldo) + CantidadDeposito;
                    context.SaveChanges();


                    //Actualizar saldo del cajero
                    Cajero.Saldo = SaldoCajero + CantidadDeposito;
                    context.SaveChanges();

                    result.Correct = true;

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
        public static Result Detalles(int NoCuenta)
        {
            Result result = new Result();
            try
            {
                using (DL.RgeronimoExamenNdsContext context = new DL.RgeronimoExamenNdsContext())
                {
                    var query = (from detallesLQ in context.UsuarioCajeros
                                 where detallesLQ.NoCuenta == NoCuenta
                                 select detallesLQ).ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            UsuarioCajero usuario = new UsuarioCajero();
                            usuario.Cajero = new Cajero();
                            usuario.IdUsuarioCajero = item.IdUsuarioCajero;
                            usuario.CantidadRetiro = (item.CantidadRetiro != null) ? item.CantidadRetiro.Value : int.Parse("0");
                            usuario.CantidadDeposito = (item.CantidadDeposito != null) ? item.CantidadDeposito.Value : int.Parse("0");
                            usuario.Cajero.IdCajero = item.IdCajero.Value;
                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El usuario no tiene movimientos";
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
