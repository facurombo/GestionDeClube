using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// Grupo: 3
// Fermin Regidor
// 29653
// Facundo Ezequiel Rombola
// 30253 

namespace Gestiondeclubesform
{
    public partial class VerJugadoresEquipos : Form
    {
        private CControladorTorneo controlador;
        public VerJugadoresEquipos(CControladorTorneo ctrl)
        {
            InitializeComponent();
            controlador = ctrl;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Equipos form2 = new Equipos(controlador);
            form2.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string codigoEquipo = textBox1.Text.Trim();
            if (!verificacionInputs())
            {
            }

            var equipo = controlador.ObtenerEquipos().FirstOrDefault(eq => eq.Codigo == codigoEquipo);

            if (equipo == null)
            {
                string message = "No se encontró un equipo con ese código.";
                string caption = "Error de entrada";
                MessageBoxButtons button = MessageBoxButtons.OK;
                sendMessage(caption, message, button);
                return;
            }

            listBox1.Items.Add($"📌 Nombre del equipo: {equipo.NombreEquipo}");

            listBox1.Items.Add($"\n🏋️ Entrenador: {equipo.Entrenador.Nombre} {equipo.Entrenador.Apellido}");
            listBox1.Items.Add("---- Jugadores ----");

            if (equipo.Jugadores.Count == 0)
            {
                listBox1.Items.Add("Este equipo no tiene jugadores.");
            }
            else
            {
                foreach (var jugador in equipo.Jugadores)
                {
                    listBox1.Items.Add($"{jugador.Apellido}, {jugador.Nombre} - Posición: {jugador.Posicion}");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e) //boton para ver todos los equipos
        {
            listBox1.Items.Clear();

            var equipos = controlador.ObtenerEquipos();

            if (equipos.Count == 0)
            {
                listBox1.Items.Add("No hay equipos registrados.");
                return;
            }

            foreach (var equipo in equipos)
            {
                listBox1.Items.Add($"📌 Equipo: {equipo.NombreEquipo} (Código: {equipo.Codigo})");
                listBox1.Items.Add($"🎨 Colores: {equipo.Colores}");
                listBox1.Items.Add($"🏋️ Entrenador: {equipo.Entrenador.Nombre} {equipo.Entrenador.Apellido}");
                listBox1.Items.Add("👥 Jugadores:");

                if (equipo.Jugadores.Count == 0)
                {
                    listBox1.Items.Add("   - Sin jugadores asignados.");
                }
                else
                {
                    foreach (var jugador in equipo.ObtenerJugadores())
                    {
                        listBox1.Items.Add($"   - {jugador.Apellido}, {jugador.Nombre} ({jugador.Posicion})");
                    }
                }

                listBox1.Items.Add("--------------------------------------------------");
            }
        }
        private bool verificacionInputs()
        {
            if (isNullOrEmpty(textBox1.Text.Trim()))
            {
                string message = "El codigo de equipo no puede estar vacio.";
                string caption = "Error de entrada";
                MessageBoxButtons button = MessageBoxButtons.OK;
                sendMessage(caption, message, button);
                return false;
            }
            return true;
        }
        private bool isNullOrEmpty(string text)
        {
            return string.IsNullOrEmpty(text);
        }
        private void sendMessage(string caption, string message, MessageBoxButtons input)
        {
            MessageBox.Show(caption, message, input);
        }

        private void VerJugadoresEquipos_Load(object sender, EventArgs e)
        {

        }
    }
}
