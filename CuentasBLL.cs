﻿using System;

namespace LoginRegistro.BLL
{
    public class CuentasBLL
    {
        public static bool Guardar(Cuenta cuenta)
        {
            if (!Existe(cuenta.CuentaId))
            {
                return Insertar(cuenta);
            }
            else
            {
                return Modificar(cuenta);
            }

        }
        private static bool Insertar(Cuenta cuenta)
        {
            bool paso = false;
            Contexto c = new Contexto();
            try
            {
                c.Cuentas.Add(cuenta);
                paso = c.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                c.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Cuenta cuenta)
        {
            bool paso = false;
            Contexto c = new Contexto();
            try
            {
                c.Entry(cuenta).State = EntityState.Modified;
                paso = c.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                c.Dispose();
            }
            return paso;
        }
        public static bool Borrar(int id)
        {
            bool paso = false;
            Contexto c = new Contexto();
            try
            {
                var cuentesita = c.Cuentas.Find(id);
                if (cuentesita != null)
                {
                    c.Cuentas.Remove(cuentesita);
                    paso = c.SaveChanges() > 0;
                }
                else
                {
                    //na xd
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                c.Dispose();
            }
            return paso;
        }
        public static Cuenta Buscar(int id)
        {
            Contexto c = new Contexto();
            Cuenta cuenta = new Cuenta();
            try
            {
                cuenta = c.Cuentas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                c.Dispose();
            }
            return cuenta;
        }
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto c = new Contexto();
            try
            {
                encontrado = c.Cuentas.Any(e => e.CuentaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                c.Dispose();
            }
            return encontrado;
        }
    }
}