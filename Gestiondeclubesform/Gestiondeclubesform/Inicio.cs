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
    public partial class Inicio : Form
    {
        private CControladorTorneo controlador;

        public Inicio(CControladorTorneo ctrl)
        {
            InitializeComponent();
            controlador = ctrl;
            this.Load += Inicio_Load;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            AgregarJugador Ventana = new AgregarJugador(controlador);
            Ventana.Show();
            this.Hide();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            AgregarEntrenador Ventana = new AgregarEntrenador(controlador);
            Ventana.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Equipos Ventana = new Equipos(controlador);
            Ventana.Show();
            this.Hide();
        }
        private void Inicio_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExpulsarJugador expulsarJugador = new ExpulsarJugador(controlador);
            expulsarJugador.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListarParticipantes listarParticipantes = new ListarParticipantes(controlador);
            listarParticipantes.Show();
            this.Hide();
        }
    }
}
