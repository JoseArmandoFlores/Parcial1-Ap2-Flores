using Microsoft.EntityFrameworkCore;
using Parcial1_Ap2_Flores.DAL;
using Parcial1_Ap2_Flores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Parcial1_Ap2_Flores.BLL
{
    public class ArticulosBLL
    {
        private static bool Insertar(Articulos articulo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Articulos.Add(articulo);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Articulos articulo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(articulo).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Existe(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                paso = db.Articulos.Any(x => x.ProductoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }
        public bool Guardar(Articulos articulo)
        {
            if (!Existe(articulo.ProductoId))
                return Insertar(articulo);
            else
                return Modificar(articulo);
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            Articulos articulo = new Articulos();

            try
            {
                articulo = db.Articulos.Find(id);

                if (articulo != null)
                {
                    db.Articulos.Remove(articulo);
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Articulos Buscar(int id)
        {
            Articulos articulo = new Articulos();
            Contexto db = new Contexto();

            try
            {
                articulo = db.Articulos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return articulo;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos,bool>>criterio)
        {
            List<Articulos> lista = new List<Articulos>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Articulos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }
    }
}
