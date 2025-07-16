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
    public partial class AgregarEquipo : Form
    {
        private CControladorTorneo controlador;

        public AgregarEquipo(CControladorTorneo ctrl)
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
        byte flag = 0;
        private void AgregarEquipo_Load(object sender, EventArgs e)
        {
            var entrenadores = controlador.ObtenerEntrenadores();

            if (flag == 0)
            {

                flag = 1;

                foreach (var entrenador in entrenadores)
                {
                    comboBox1.Items.Add(entrenador);
                }

            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (verificacionInputs() && sinRepeticiones())
            {
                try
                {
                    string codigo = textBox4.Text.Trim();  // Código del equipo
                    string nombre = textBox1.Text.Trim();  // Nombre del equipo
                    string colores = textBox2.Text.Trim(); // Colores
                    
                    if (comboBox1.SelectedItem == null)
                    {
                        MessageBox.Show("Seleccioná un entrenador.");
                        return;
                    }

                    // Obtenés el entrenador directamente del ComboBox
                    var entrenadorSeleccionado = comboBox1.SelectedItem as CEntrenador;
                    int dniEntrenador = entrenadorSeleccionado.CodigoIdentificacion;

                    string resultado = controlador.CrearEquipoDesdeForm(codigo, nombre, colores, dniEntrenador);
                    MessageBox.Show(resultado);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el equipo: " + ex.Message);
                }
            }

        }
        private bool sinRepeticiones()
        {
            foreach (var equipo in controlador.ObtenerEquipos())
            {
                if(equipo.Codigo == textBox4.Text.Trim())
                {
                    string message = "El codigo del equipo ya existe.";
                    string caption = "Error de entrada";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    sendMessage(caption, message, button);
                    return false;
                }
            }
            return true;
        }
        private bool verificacionInputs()
        {
            if (isNullOrEmpty(textBox4.Text.Trim()))
            {
                string message = "El codigo del equipo no puede estar vacio.";
                string caption = "Error de entrada";
                MessageBoxButtons button = MessageBoxButtons.OK;
                sendMessage(caption, message, button);
                return false;
            }
            if (isNullOrEmpty(textBox1.Text.Trim()))
            {
                string message = "El nombre del equipo no puede estar vacio.";
                string caption = "Error de entrada";
                MessageBoxButtons button = MessageBoxButtons.OK;
                sendMessage(caption, message, button);
                return false;
            }
            if (isNullOrEmpty(textBox2.Text.Trim()))
            {
                string message = "Los colores del equipo no pueden estar vacios.";
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
    }
}
