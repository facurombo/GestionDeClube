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
    public partial class Ingreso : Form
    {
        public Ingreso()
        {
            InitializeComponent();
        }
        private CControladorTorneo controlador;

        public Ingreso(CControladorTorneo ctrl)
        {
            InitializeComponent();
            controlador = ctrl;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contraseña = textBox2.Text;
            if (verificacionInputs())
            {
                if (usuario == "admin" && contraseña == "1234")
                {
                    Inicio form2 = new Inicio(controlador);
                    form2.Show();
                    this.Hide(); // Oculta el formulario de login
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Clear();
                    textBox2.Focus();
                }
            }
        }
        private bool verificacionInputs()
        {
            if (isNullOrEmpty(textBox1.Text.Trim()))
            {
                string message = "El usuario no puede estar vacio.";
                string caption = "Error de entrada";
                MessageBoxButtons button = MessageBoxButtons.OK;
                sendMessage(caption, message, button);
                return false;
            }
            if (isNullOrEmpty(textBox2.Text.Trim()))
            {
                string message = "La contraseña no puede estar vacia";
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
