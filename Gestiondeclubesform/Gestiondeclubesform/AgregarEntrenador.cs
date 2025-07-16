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
    public partial class AgregarEntrenador : Form
    {

        private CControladorTorneo controlador;
        public AgregarEntrenador(CControladorTorneo ctrl)
        {
            InitializeComponent();
            controlador = ctrl;
        }

        private void button1_Click(object sender, EventArgs e) //volver atras
        {
            Inicio form2 = new Inicio(controlador);
            form2.Show();
            this.Close();
        }
        private void button7_Click(object sender, EventArgs e) //aceptar y agregar
        {
            if (verificacionInputs() && sinRepeticiones()) 
            {
                try
                {
                    string nombre = textBox1.Text.Trim();       // nombre
                    string apellido = textBox2.Text.Trim();     // apellido
                    int dni = int.Parse(textBox4.Text.Trim());  // DNI
                    int telefono = int.Parse(textBox5.Text.Trim());

                    var entrenador = new CEntrenador(nombre, apellido, dni, telefono);
                    controlador.AgregarEntrenadorDesdeForm(entrenador);

                    MessageBox.Show("Entrenador agregado correctamente.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar entrenador: " + ex.Message);
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
            if(isNullOrEmpty(textBox1.Text.Trim()))
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
            if (isNullOrEmpty(textBox5.Text.Trim()) || !int.TryParse(textBox5.Text.Trim(), out _))
            {
                string message = "El teléfono debe ser un número válido.";
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
