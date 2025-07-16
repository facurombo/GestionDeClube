using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestiondeclubesform
{
    public partial class ExpulsarJugador : Form
    {
        private CControladorTorneo controlador;
        public ExpulsarJugador(CControladorTorneo controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio form2 = new Inicio(controlador);
            form2.Show();
            this.Hide();
        }

        byte flag = 0;
        private void expulsarJugador_Load(object sender, EventArgs e)
        {
            var jugadores = controlador.ObtenerJugadores();

            if (flag == 0)
            {

                flag = 1;

                var jugadoresOrdenados = jugadores.OrderBy(j => j.Apellido).ToList();

               foreach (var jugador in jugadoresOrdenados)
                {
                    comboBox1.Items.Add(jugador);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var jugadorSeleccionado = comboBox1.SelectedItem as CJugador;
            if (jugadorSeleccionado != null)
            {
                try
                {
                    controlador.expulsarJugador(jugadorSeleccionado);
                    sendMessage("Jugador expulsado", $"El jugador {jugadorSeleccionado.Nombre} {jugadorSeleccionado.Apellido} ha sido expulsado correctamente.", MessageBoxButtons.OK);
                    comboBox1.Items.Remove(jugadorSeleccionado);
                }
                catch (Exception ex)
                {
                    sendMessage("Error al expulsar jugador", $"No se pudo expulsar al jugador: {ex.Message}", MessageBoxButtons.OK);
                }
            }
            else
            {
                sendMessage("Error de selección", "Por favor, selecciona un jugador para expulsar.", MessageBoxButtons.OK);
            }
        }
        private void sendMessage(string caption, string message, MessageBoxButtons input)
        {
            MessageBox.Show(caption, message, input);
        }
    }
}
