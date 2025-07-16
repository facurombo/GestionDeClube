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
    public partial class ListarParticipantes : Form
    {
        private CControladorTorneo controladora;
        public ListarParticipantes(CControladorTorneo controladora)
        {
            InitializeComponent();
            this.controladora = controladora;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListarEntrenadores listarEntrenadores = new ListarEntrenadores(controladora);
            listarEntrenadores.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListarTodos listarTodos = new ListarTodos(controladora);
            listarTodos.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio(controladora);
            inicio.Show();
            this.Hide();
        }

        private void ListarParticipantes_Load(object sender, EventArgs e)
        {

        }
    }
}
