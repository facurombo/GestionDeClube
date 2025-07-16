using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Grupo: 3
// Fermin Regidor
// 29653
// Facundo Ezequiel Rombola
// 30253 

namespace Gestiondeclubesform
{
    public class CEquipo 
    {
        public string Codigo { get; private set; }
        public string NombreEquipo {get; private set;}
        public string Colores { get; private set; }

        public List<CJugador> Jugadores { get;  private set; }

        public CEntrenador Entrenador { get;  private set; }

        public CEquipo (string codigo, string nombreequipo, string colores, CEntrenador entrenador)
        {

        this.Codigo = codigo;
        this.NombreEquipo = nombreequipo;
        this.Colores = colores;
        Jugadores = new List<CJugador>();

        this.Entrenador = entrenador;    
         Entrenador.DirigirEquipo(this);

        }

        public bool AgregarJugador(CJugador jugador)
        {
            
            if (Jugadores.Contains(jugador))
            {
                return false;
            }
            if (jugador.Edad < 18 || jugador.Edad > 45)
            {
                return false;
            }

            if (Jugadores.Count >= 23)
            {
                return false;
            }

            Jugadores.Add(jugador);
            return true;

        }

    

        public List<CJugador> ObtenerJugadores() => Jugadores.OrderBy(j => j.Apellido).ToList();

        public bool EsValido()
        {
            int total = Jugadores.Count;
            int arqueros = Jugadores.Count(j => j.Posicion.ToLower() == "arquero");

            return total >= 11 && total <= 23 && arqueros >= 1;
        }

        public void quitarJugador(CJugador jugador)
        {
            if (Jugadores.Contains(jugador))
            {
                Jugadores.Remove(jugador);
            }
        }


    }
}
