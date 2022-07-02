using System;
using System.ComponentModel;

namespace Dominio
{
    public class Pokemon
    {
        private int id;
        private int numero;
        private string nombre;
        private string descripcion;
        private string urlImagen;
        private Elemento tipo;
        private Elemento debilidad;
        public Pokemon(int id, int numero, string nombre, string descripcion, string urlImagen, Elemento tipo, Elemento debilidad)
        {
            this.id = id;
            this.numero = numero;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.urlImagen = urlImagen;
            this.tipo = tipo;
            this.debilidad = debilidad;
        }
        public Pokemon()
        {

        }
        public int Id { get { return id;} set { id = value; } }
        [DisplayName("Número")]
        public int Numero { get { return numero; } set { numero = value; } }
        public string Nombre { get => nombre; set => nombre = value; }
        [DisplayName("Descripción")]
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public string UrlImagen { get { return urlImagen; } set { urlImagen = value; } }
        public Elemento Tipo { get => tipo; set => tipo = value; }
        public Elemento Debilidad { get => debilidad; set => debilidad = value; }
}
}
