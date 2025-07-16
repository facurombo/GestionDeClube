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
    public partial class ListarEntrenadores : Form
    {
        private CControladorTorneo controladora;
        public ListarEntrenadores(CControladorTorneo controladora)
        {
            InitializeComponent();
            this.controladora = controladora;
        }

        private void ListarEntrenadores_Load(object sender, EventArgs e)
        {
            var entrenadores = controladora.ObtenerEntrenadores();
            var equipos = controladora.ObtenerEquipos();

            if (entrenadores.Count == 0)
            {
                listBox1.Items.Add("No hay jugadores registrados.");
                return;
            }

            var entrenadoresOrdenados = entrenadores.OrderBy(j => j.Apellido).ToList();

            foreach (var entrenador in entrenadoresOrdenados)
            {
                listBox1.Items.Add($"Entrenador: {entrenador.Nombre} {entrenador.Apellido} - \nDNI: {entrenador.CodigoIdentificacion} - Telefono: {entrenador.Telefono} - Equipos: {entrenador.ObtenerEquipos()}");
                listBox1.Items.Add("-");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListarParticipantes form2 = new ListarParticipantes(controladora);
            form2.Show();
            this.Hide();
        }
    }
}
