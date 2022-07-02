using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
namespace Vista
{
    public partial class frmMenu : Form
    {
        private PokemonNegocio pokemonNegocio;
        private List<Pokemon> listaPokemones;
        public frmMenu()
        {
            InitializeComponent();
            pokemonNegocio = new PokemonNegocio();
            listaPokemones = new List<Pokemon>();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void dgvPokemones_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvPokemones.CurrentRow != null)
            {
                Pokemon aux = (Pokemon)dgvPokemones.CurrentRow.DataBoundItem;
                CargarImagen(aux.UrlImagen);
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

        private void btnAgregarPokemon_Click(object sender, EventArgs e)
        {
            frmAltaPokemon nuevaVentana = new frmAltaPokemon();
            nuevaVentana.ShowDialog();
            ActualizarLista();
        }
        public void ActualizarLista()
        {
            dgvPokemones.DataSource = null;
            listaPokemones = pokemonNegocio.Listar();
            dgvPokemones.DataSource = listaPokemones;
            this.CargarImagen(listaPokemones[0].UrlImagen);
            this.OcultarColumnas();
        }

        private void btnModificarPokemon_Click(object sender, EventArgs e)
        {
            Pokemon pokemon = (Pokemon)dgvPokemones.CurrentRow.DataBoundItem;
            frmModificarPokemon ventanaModificar = new frmModificarPokemon(pokemon);
            ventanaModificar.ShowDialog();
            this.ActualizarLista();
        }

        private void btnEliminarLogica_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon pokemon = (Pokemon)dgvPokemones.CurrentRow.DataBoundItem;
                DialogResult respuesta =   MessageBox.Show("Seguro que quieres hacer la baja?","Baja",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(respuesta == DialogResult.Yes)
                    pokemonNegocio.EliminarLogicamente(pokemon.Id);
                this.ActualizarLista();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon pokemon = (Pokemon)dgvPokemones.CurrentRow.DataBoundItem;
                DialogResult respuesta = MessageBox.Show("Seguro que quieres hacer la baja?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                    pokemonNegocio.EliminarFisicamente(pokemon.Id);
                this.ActualizarLista();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada;
            string filtro = txtFiltro.Text;
            if (filtro != string.Empty)
                listaFiltrada = listaPokemones.FindAll((x) => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
            else
                listaFiltrada = listaPokemones;

            dgvPokemones.DataSource = null;
            dgvPokemones.DataSource = listaFiltrada;
            this.OcultarColumnas();
        }
        private void OcultarColumnas()
        {
            dgvPokemones.Columns["UrlImagen"].Visible = false;
            dgvPokemones.Columns["Id"].Visible = false;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada;
            string filtro = txtFiltro.Text;
            if (filtro != string.Empty)
                listaFiltrada = listaPokemones.FindAll((x) => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
            else
                listaFiltrada = listaPokemones;

            dgvPokemones.DataSource = null;
            dgvPokemones.DataSource = listaFiltrada;
            this.OcultarColumnas();
        }
    }
}
