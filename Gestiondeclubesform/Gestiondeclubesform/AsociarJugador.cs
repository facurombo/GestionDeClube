using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Grupo: 3
// Fermin Regidor
// 29653
// Facundo Ezequiel Rombola
// 30253 

namespace Gestiondeclubesform
{
    public partial class AsociarJugador : Form
    {
        private CControladorTorneo controlador;

        public AsociarJugador(CControladorTorneo ctrl)
        {
            InitializeComponent();
            controlador = ctrl;
        }

        private void AsociarJugador_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();  // ← Esto es esencial

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cargar equipos
            var listaEquipos = controlador.ObtenerEquipos();
            comboBox1.DisplayMember = "NombreEquipo";
            foreach (var equipo in listaEquipos)
                comboBox1.Items.Add(equipo);

            // Obtener jugadores no asignados
            var todosLosJugadores = controlador.ObtenerJugadores();
            var jugadoresAsignados = listaEquipos.SelectMany(eq => eq.Jugadores).Distinct();
            var jugadoresSinEquipo = todosLosJugadores.Where(j => !jugadoresAsignados.Contains(j)).ToList();

            comboBox2.DisplayMember = "NombreCompleto";
            foreach (var jugador in jugadoresSinEquipo)
                comboBox2.Items.Add(jugador);

        }

        private void button1_Click(object sender, EventArgs e) //IR ATRAS
        {
            Equipos form2 = new Equipos(controlador);
            form2.Show();
            this.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                string message = "Debes seleccionar un equipo y un jugador.";
                string caption = "Error de entrada";
                MessageBoxButtons button = MessageBoxButtons.OK;
                sendMessage(caption, message, button);
                return;
            }

            var equipo = comboBox1.SelectedItem as CEquipo;
            var jugador = comboBox2.SelectedItem as CJugador;

            if (equipo == null || jugador == null)
            {
                string message = "Error en la selección de equipo o jugador.";
                string caption = "Error de entrada";
                MessageBoxButtons button = MessageBoxButtons.OK;
                sendMessage(caption, message, button);
                return;
            }

            string resultado = controlador.AsociarJugadorEquipo(equipo.Codigo, jugador.CodigoIdentificacion);
            MessageBox.Show(resultado);


            // Refrescar combos después de la asociación
            AsociarJugador_Load(sender, e); // vuelve a cargar el formulario y actualiza las listas
        }
        private void sendMessage(string caption, string message, MessageBoxButtons input)
        {
            MessageBox.Show(caption, message, input);
        }
    }
}
