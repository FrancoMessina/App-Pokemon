using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Dominio;
namespace Negocio
{
    public class PokemonNegocio
    {
      
        public List<Pokemon> Listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            GestorSQL accesoDatos = new GestorSQL();
            try
            {
                string query = "Select P.Id, P.Numero, P.Nombre, P.Descripcion, UrlImagen,E.Id, E.Descripcion Tipo,D.Id, D.Descripcion Debilidad From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad";
                accesoDatos.SetQuery(query);
                accesoDatos.EjecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    
                    int id = accesoDatos.Lector.GetInt32(0);
                    int numero = accesoDatos.Lector.GetInt32(1);
                    string nombre = accesoDatos.Lector.GetString(2);
                    string descripcion = accesoDatos.Lector.GetString(3);
                    string urlImagen = accesoDatos.Lector["UrlImagen"] is not DBNull ? accesoDatos.Lector.GetString(4): string.Empty;
                    int idTipo = accesoDatos.Lector.GetInt32(5);
                    string descripcionTipo = accesoDatos.Lector.GetString(6);
                    int idDebilidad = accesoDatos.Lector.GetInt32(7);
                    string descripcionDebilidad = accesoDatos.Lector.GetString(8);
                    Elemento tipo = new Elemento(idTipo,descripcionTipo);
                    Elemento debilidad = new Elemento(idDebilidad, descripcionDebilidad);
                    lista.Add(new Pokemon(id,numero, nombre, descripcion, urlImagen, tipo, debilidad));
                }
                return lista;
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
        public void AgregarPokemon(Pokemon pokemon)
        {
            GestorSQL accesoDatos = new GestorSQL();
            try
            {
                string query = "Insert into Pokemons (Numero,Nombre,Descripcion,Activo,IdTipo,IdDebilidad,UrlImagen) values (" +
                    "@numero,@nombre,@descripcion,1,@IdTipo,@IdDebilidad,@UrlImagen)";
                accesoDatos.SetQuery(query);
                accesoDatos.SetearParametro("numero", pokemon.Numero);
                accesoDatos.SetearParametro("nombre", pokemon.Nombre);
                accesoDatos.SetearParametro("descripcion", pokemon.Descripcion);
                accesoDatos.SetearParametro("IdTipo", pokemon.Tipo.Id);
                accesoDatos.SetearParametro("IdDebilidad", pokemon.Debilidad.Id);
                accesoDatos.SetearParametro("UrlImagen", pokemon.UrlImagen);
                accesoDatos.EjecutarAccion();
                
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
        public void ModificarPokemon(Pokemon pokemon)
        {
            GestorSQL accesoDatos = new GestorSQL();
            try
            {
                string query = "Update  POKEMONS set Numero = @numero ,Nombre = @nombre, Descripcion " +
                    "= @descripcion,UrlImagen = @UrlImagen,IdTipo = @IdTipo,IdDebilidad = @IdDebilidad where Id = @Id";
                accesoDatos.SetQuery(query);
                accesoDatos.SetearParametro("numero", pokemon.Numero);
                accesoDatos.SetearParametro("nombre", pokemon.Nombre);
                accesoDatos.SetearParametro("descripcion", pokemon.Descripcion);
                accesoDatos.SetearParametro("IdTipo", pokemon.Tipo.Id);
                accesoDatos.SetearParametro("IdDebilidad", pokemon.Debilidad.Id);
                accesoDatos.SetearParametro("UrlImagen", pokemon.UrlImagen);
                accesoDatos.SetearParametro("Id", pokemon.Id);
                accesoDatos.EjecutarAccion();

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
        public void EliminarLogica(int id)
        {
            GestorSQL accesoDatos = new GestorSQL();
            try
            {
                string query = "Update  POKEMONS set Activo = 0 where Id = @Id";
                accesoDatos.SetQuery(query);
                accesoDatos.SetearParametro("Id", id);
                accesoDatos.EjecutarAccion();
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
        public void EliminarLogicamente(int id)
        {
            GestorSQL accesoDatos = new GestorSQL();
            try
            {
                string query = "Update  POKEMONS set Activo = 0 where Id = @Id";
                accesoDatos.SetQuery(query);
                accesoDatos.SetearParametro("Id", id);
                accesoDatos.EjecutarAccion();
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
        public void EliminarFisicamente(int id)
        {
            GestorSQL accesoDatos = new GestorSQL();
            try
            {
                string query = "Delete pokemons where Id = @Id";
                accesoDatos.SetQuery(query);
                accesoDatos.SetearParametro("Id", id);
                accesoDatos.EjecutarAccion();
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

