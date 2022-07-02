using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Vista
{
    public partial class frmAltaPokemon : Form
    {
        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon nuevoPokemon = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                nuevoPokemon.Numero = int.Parse(txtNumero.Text);
                nuevoPokemon.Nombre = txtNombre.Text;
                nuevoPokemon.Descripcion = txtDescripcion.Text;
                nuevoPokemon.Tipo = (Elemento)cmbTipo.SelectedItem;
                nuevoPokemon.Debilidad = (Elemento)cmbDebilidad.SelectedItem;
                nuevoPokemon.UrlImagen = txtUrlImagen.Text;
                negocio.AgregarPokemon(nuevoPokemon);
                MessageBox.Show("Agregado Exitosamente!");
                this.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            try
            {
                cmbTipo.DataSource = elementoNegocio.ListarElementos();
                cmbDebilidad.DataSource = elementoNegocio.ListarElementos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            try
            {
                this.CargarImagen(txtUrlImagen.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void CargarImagen(string imagen)
        {
            try
            {
                pbxPokemon.Load(imagen);
            }
            catch (Exception)
            {
                pbxPokemon.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }

        }
    }
}
