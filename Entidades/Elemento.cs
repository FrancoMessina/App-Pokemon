using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Elemento
    {
        private int id;
        private string descripcion;
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Elemento()
        {

        }
        public Elemento(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }
        public override string ToString()
        {
            return Descripcion; 
        }
    }
}
