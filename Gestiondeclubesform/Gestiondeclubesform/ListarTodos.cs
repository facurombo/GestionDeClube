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
    public partial class ListarTodos : Form 
    {
        private CControladorTorneo controladora;
        public ListarTodos(CControladorTorneo controladora)
        {
            InitializeComponent();
            this.controladora = controladora;
        }

        private void ListarTodos_Load(object sender, EventArgs e)
        {
            var jugadores = controladora.ObtenerJugadores();
            var entrenadores = controladora.ObtenerEntrenadores();

            var participantes = new List<(string Apellido, string Texto)>();

            foreach (var jugador in jugadores)
            {
                string equipo = verificacionPerteneceEquipo(jugador.CodigoIdentificacion);
                string texto = $"\nJugador: {jugador.Nombre} {jugador.Apellido} - \nPosición: {jugador.Posicion} - \nEquipo: {equipo} - \nDNI: {jugador.CodigoIdentificacion} - \nFecha de Nacimiento: {jugador.Nacimiento.ToShortDateString()} \n";
                participantes.Add((jugador.Apellido, texto));

                
            }

            foreach (var entrenador in entrenadores)
            {
                string texto = $"Entrenador: {entrenador.Nombre} {entrenador.Apellido} - Teléfono: {entrenador.Telefono} - \nDNI: {entrenador.CodigoIdentificacion} - Equipos: {entrenador.ObtenerEquipos() }";
                participantes.Add((entrenador.Apellido, texto));
            }

            
            var participantesOrdenados = participantes.OrderBy(p => p.Apellido).ToList();

           
            if (participantesOrdenados.Count == 0)
            {
                listBox1.Items.Add("No hay jugadores ni entrenadores registrados.");
                return;
            }

            foreach (var persona in participantesOrdenados)
            {
                listBox1.Items.Add(persona.Texto);
                listBox1.Items.Add("-");
            }

            
        }

        private string verificacionPerteneceEquipo(int dni)
        {
            var equipos = controladora.ObtenerEquipos();
            foreach (var equipo in equipos)
            {
                if (equipo.Jugadores.Any(j => j.CodigoIdentificacion == dni))
                {
                    return equipo.NombreEquipo;
                }
            }
            return "No pertenece a ningún equipo";
        }

      
        private void button1_Click_1(object sender, EventArgs e)
        {
            ListarParticipantes form2 = new ListarParticipantes(controladora);
            form2.Show();
            this.Hide();
        }
    }
}
