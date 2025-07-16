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
    public partial class Equipos : Form
    {
        private CControladorTorneo controlador;

        public Equipos(CControladorTorneo ctrl)
        {
            InitializeComponent();
            controlador = ctrl;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio form2 = new Inicio(controlador);
            form2.Show();
            this.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            AgregarEquipo form2 = new AgregarEquipo(controlador);
            form2.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            VerJugadoresEquipos form2 = new VerJugadoresEquipos(controlador);
            form2.Show();
            this.Hide();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            AsociarJugador form2 = new AsociarJugador(controlador);
            form2.Show();
            this.Hide();
        }
    }
}
