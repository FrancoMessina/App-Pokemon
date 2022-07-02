using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class ElementoNegocio
    {
        public List<Elemento> ListarElementos()
        {
            GestorSQL accesoDatos = new GestorSQL();
            List<Elemento> listaElementos = new List<Elemento>();
            try
            {
                accesoDatos.SetQuery("Select Id, Descripcion From ELEMENTOS");
                accesoDatos.EjecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    Elemento aux = new Elemento();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    listaElementos.Add(aux);
                }
                return listaElementos;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
            
        }
    }
}
