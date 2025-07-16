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
    public class CControladorTorneo
    {
        private CConjuntoEntrenadores entrenadores;
        private CConjuntoEquipos equipos;
        private CConjuntoJugadores jugadores;

        public CControladorTorneo()
        {
            jugadores = new CConjuntoJugadores();
            entrenadores = new CConjuntoEntrenadores();
            equipos = new CConjuntoEquipos();
        }

        // Jugadores
        public void AgregarJugadorDesdeForm(CJugador jugador)
        {
            jugadores.AgregarJugador(jugador);
        }

        public List<CJugador> ObtenerJugadores()
        {
            return jugadores.ObtenerTodos();
        }

        public List<CJugador> ObtenerJugadoresDeEquipo(string codigoEquipo)
        {
            var equipo = equipos.BuscarPorCodigo(codigoEquipo);
            return equipo?.ObtenerJugadores() ?? new List<CJugador>();
        }

        public void expulsarJugador(CJugador jugador)
        {
            jugadores.ObtenerTodos().Remove(jugador);
            foreach (var equipo in equipos.ObtenerTodos())
            {
                equipo.quitarJugador(jugador);
            }
        }
        // Entrenadores
        public void AgregarEntrenadorDesdeForm(CEntrenador entrenador)
        {
            entrenadores.AgregarEntrenador(entrenador);
        }

        public List<CEntrenador> ObtenerEntrenadores()
        {
            return entrenadores.ObtenerTodos();
        }

        // Equipos
        public string CrearEquipoDesdeForm(string codigo, string nombre, string colores, int dniEntrenador)
        {
            var entrenador = entrenadores.ObtenerTodos().FirstOrDefault(e => e.CodigoIdentificacion == dniEntrenador);
            if (entrenador == null)
                return "Entrenador no encontrado.";

            var equipo = new CEquipo(codigo, nombre, colores, entrenador);
            equipos.AgregarEquipo(equipo);
            return "Equipo creado con éxito.";
        }

        public List<CEquipo> ObtenerEquipos()
        {
            return equipos.ObtenerTodos();
        }

        public string AsociarJugadorEquipo(string codigoEquipo, int dniJugador)
        {
            var equipo = equipos.BuscarPorCodigo(codigoEquipo);
            if (equipo == null) return "Equipo no encontrado.";

            var jugador = jugadores.ObtenerTodos().FirstOrDefault(j => j.CodigoIdentificacion == dniJugador);
            if (jugador == null) return "Jugador no encontrado.";

            bool yaAsociado = equipos.ObtenerTodos().Any(e => e.Jugadores.Contains(jugador));
            if (yaAsociado) return "El jugador ya está en un equipo.";

            bool agregado = equipo.AgregarJugador(jugador);
            return agregado ? "Jugador agregado correctamente." : "No se pudo agregar (edad o cantidad inválida).";
        }

        // Participantes
        public List<string> ListarParticipantes()
        {
            var lista = new List<string>();
            lista.Add("=== Jugadores ===");

            foreach (var j in jugadores.ObtenerTodos())
            {
                string equiposDelJugador = string.Join(", ",
                    equipos.ObtenerTodos().Where(eq => eq.Jugadores.Contains(j)).Select(eq => eq.NombreEquipo));

                lista.Add($"{j.Apellido}, {j.Nombre} - {j.Posicion} - Equipos: {equiposDelJugador}");
            }

            lista.Add("=== Entrenadores ===");

            foreach (var e in entrenadores.ObtenerTodos())
            {
                string equiposDirigidos = string.Join(", ", e.Equipos.Select(eq => eq.NombreEquipo));
                lista.Add($"{e.Apellido}, {e.Nombre} - Tel: {e.Telefono} - Equipos: {equiposDirigidos}");
            }

            return lista;
        }
    }
}
