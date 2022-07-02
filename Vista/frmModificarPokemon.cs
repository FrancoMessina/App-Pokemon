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
    public partial class frmModificarPokemon : Form
    {
        private Pokemon pokemon;
        private PokemonNegocio pokemonNegocio;
        private ElementoNegocio elementoNegocio;
        public frmModificarPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
            this.pokemonNegocio = new PokemonNegocio();
            this.elementoNegocio = new ElementoNegocio();

        }

        private void frmModificarPokemon_Load(object sender, EventArgs e)
        {
            try
            {
                SetearControles();
                txtNumero.Text = pokemon.Numero.ToString();
                txtNombre.Text = pokemon.Nombre;
                txtDescripcion.Text = pokemon.Descripcion;
                txtUrlImagen.Text = pokemon.UrlImagen;
                CargarImagen(pokemon.UrlImagen);
                
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                pokemon.Numero = int.Parse(txtNumero.Text);
                pokemon.Nombre = txtNombre.Text;
                pokemon.Descripcion = txtDescripcion.Text;
                pokemon.Tipo = (Elemento)cmbTipo.SelectedItem;
                pokemon.Debilidad = (Elemento)cmbDebilidad.SelectedItem;
                pokemon.UrlImagen = txtUrlImagen.Text;
                pokemonNegocio.ModificarPokemon(pokemon);
                MessageBox.Show("Modificado Exitosamente!");
                this.Close();

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
        private void SetearControles()
        {
            cmbTipo.DataSource = elementoNegocio.ListarElementos();
            cmbTipo.ValueMember = "Id";
            cmbTipo.DisplayMember = "Descripcion";
            cmbDebilidad.DataSource = elementoNegocio.ListarElementos();
            cmbDebilidad.ValueMember = "Id";
            cmbDebilidad.DisplayMember = "Descripcion";
            cmbTipo.SelectedValue = pokemon.Tipo.Id;
            cmbDebilidad.SelectedValue = pokemon.Debilidad.Id;
        }
    }
}
