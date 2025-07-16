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
    public partial class AgregarJugador : Form
    {
        private CControladorTorneo controlador;

        public AgregarJugador(CControladorTorneo ctrl)
        {
            InitializeComponent();
            controlador = ctrl;
        }


        private void button1_Click(object sender, EventArgs e) //atras
        {
            Inicio form2 = new Inicio(controlador);
            form2.Show();
            this.Hide();
        }
        private void button7_Click(object sender, EventArgs e) // finalizar y agregar
        {
            if(verificacionInputs() && sinRepeticiones())
            {
                try
                {
                    string nombre = textBox1.Text.Trim();       // nombre
                    string apellido = textBox2.Text.Trim();     // apellido
                    string posicion = textBox5.Text.Trim();     // posición
                    int dni = int.Parse(textBox4.Text.Trim());  // DNI
                    DateTime nacimiento = DateTime.Parse(textBox3.Text.Trim()); // fecha nacimiento

                    var jugador = new CJugador(nombre, apellido, dni, posicion, nacimiento);
                    controlador.AgregarJugadorDesdeForm(jugador);

                    MessageBox.Show("Jugador agregado correctamente.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar jugador: " + ex.Message);
                }
            }
        }
        private bool sinRepeticiones()
        {
            foreach (var entrenador in controlador.ObtenerEntrenadores())
            {
                if (entrenador.CodigoIdentificacion == int.Parse(textBox4.Text))
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
            if (isNullOrEmpty(textBox1.Text.Trim()))
            {
                string message = "El nombre no puede estar vacío.";
                string caption = "Error de entrada";
                MessageBoxButtons button = MessageBoxButtons.OK;
                sendMessage(caption, message, button);
                return false;
            }
            if (isNullOrEmpty(textBox2.Text.Trim()))
            {
                string message = "El apellido no puede estar vacío.";
                string caption = "Error de entrada";
                MessageBoxButtons button = MessageBoxButtons.OK;
                sendMessage(caption, message, button);
                return false;
            }
            if (isNullOrEmpty(textBox4.Text.Trim()) || !int.TryParse(textBox4.Text.Trim(), out _))
            {
                string message = "El DNI debe ser un número válido.";
                string caption = "Error de entrada";
                MessageBoxButtons button = MessageBoxButtons.OK;
                sendMessage(caption, message, button);
                return false;
            }
            if (isNullOrEmpty(textBox5.Text.Trim()))
            {
                string message = "La posiciom no puede estar vacia.";
                string caption = "Error de entrada";
                MessageBoxButtons button = MessageBoxButtons.OK;
                sendMessage(caption, message, button);
                return false;
            }
            if(isNullOrEmpty(textBox3.Text.Trim()) || !DateTime.TryParse(textBox3.Text.Trim(), out _))
            {
                string message = "La fecha de nacimiento debe ser una fecha válida.";
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
