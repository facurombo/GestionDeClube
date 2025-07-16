using System;
using System.Collections.Generic;
using System.Linq;

// Grupo: 3
// Fermin Regidor
// 29653
// Facundo Ezequiel Rombola
// 30253 

namespace Gestiondeclubesform
{
    
    public class CConjuntoJugadores
    {
        private List<CJugador> jugadores = new List<CJugador>();

        public void AgregarJugador(CJugador jugador)
        {
            jugadores.Add(jugador);
        }

        public List<CJugador> ObtenerTodos()
        {
            return jugadores;
        }
    }

    public class CConjuntoEntrenadores
    {
        private List<CEntrenador> entrenadores = new List<CEntrenador>();

        public void AgregarEntrenador(CEntrenador entrenador)
        {
            entrenadores.Add(entrenador);
        }

        public List<CEntrenador> ObtenerTodos()
        {
            return entrenadores;
        }
    }

    public class CConjuntoEquipos
    {
        private List<CEquipo> equipos = new List<CEquipo>();

        public void AgregarEquipo(CEquipo equipo)
        {
            if (!equipos.Any(e => e.Codigo == equipo.Codigo))
                equipos.Add(equipo);
        }

        public List<CEquipo> ObtenerTodos()
        {
            return equipos;
        }

        public CEquipo BuscarPorCodigo(string codigo)
        {
            return equipos.FirstOrDefault(e => e.Codigo == codigo);
        }
    }
}
