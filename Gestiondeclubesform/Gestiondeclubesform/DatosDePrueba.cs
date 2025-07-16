using Gestiondeclubesform;
using System;
using System.Collections.Generic;

// Grupo: 3
// Fermin Regidor
// 29653
// Facundo Ezequiel Rombola
// 30253 

public static class DatosDePrueba
{
    public static void Cargar(CControladorTorneo controlador)
    {
        var entrenador1 = new CEntrenador("Juan", "Pérez", 12345678, 11334455);
        var entrenador2 = new CEntrenador("Ana", "Gómez", 23456789, 11445566);
        var entrenador3 = new CEntrenador("Marcos", "Díaz", 34567890, 11778899);
        var entrenador4 = new CEntrenador("Lucía", "Ramírez", 45678901, 11667788);

        controlador.AgregarEntrenadorDesdeForm(entrenador1);
        controlador.AgregarEntrenadorDesdeForm(entrenador2);
        controlador.AgregarEntrenadorDesdeForm(entrenador3);
        controlador.AgregarEntrenadorDesdeForm(entrenador4);

        // Jugadores (más de 44 para 4 equipos)
        var jugadores = new List<CJugador>
        {
            new CJugador("Lucas", "Martínez", 30111222, "Arquero", new DateTime(2000, 5, 20)),
            new CJugador("Mateo", "Rodríguez", 30111333, "Defensor", new DateTime(1999, 8, 10)),
            new CJugador("Sofía", "López", 30111444, "Delantero", new DateTime(1990, 12, 2)),
            new CJugador("Bruno", "Fernández", 30111555, "Mediocampista", new DateTime(2001, 3, 15)),
            new CJugador("Carlos", "Ruiz", 30111666, "Defensor", new DateTime(1995, 7, 1)),
            new CJugador("Joaquín", "Gómez", 30111777, "Mediocampista", new DateTime(1993, 11, 22)),
            new CJugador("Agustín", "Fernández", 30111888, "Delantero", new DateTime(1998, 4, 9)),
            new CJugador("Mariano", "Suárez", 30111999, "Defensor", new DateTime(1996, 9, 14)),
            new CJugador("Nicolás", "García", 30112000, "Mediocampista", new DateTime(2002, 6, 30)),
            new CJugador("Diego", "Castro", 30112111, "Delantero", new DateTime(1989, 1, 5)),
            new CJugador("Tomás", "Rivas", 30112222, "Defensor", new DateTime(2000, 2, 27)),
            new CJugador("Martina", "Bianchi", 30112333, "Arquero", new DateTime(1994, 9, 12)),
            new CJugador("Leo", "Messina", 30112444, "Delantero", new DateTime(1990, 11, 17)),
            new CJugador("Ramiro", "López", 30112555, "Mediocampista", new DateTime(1993, 6, 8)),
            new CJugador("Luciano", "Paredes", 30112666, "Defensor", new DateTime(1998, 3, 21)),
            new CJugador("Cintia", "Romero", 30112777, "Mediocampista", new DateTime(2001, 12, 4)),
            new CJugador("Daniel", "Morales", 30112888, "Delantero", new DateTime(2000, 5, 9)),
            new CJugador("Erika", "Sosa", 30112999, "Arquero", new DateTime(1997, 10, 30)),
            new CJugador("Fabián", "Torres", 30113000, "Defensor", new DateTime(1996, 1, 19)),
            new CJugador("Gabriel", "Gutiérrez", 30113111, "Delantero", new DateTime(1985, 4, 22)),
            new CJugador("Hernán", "Álvarez", 30113222, "Defensor", new DateTime(1992, 8, 11)),
            new CJugador("Iván", "Bustos", 30113333, "Arquero", new DateTime(1999, 2, 18)),
            new CJugador("Jimena", "Navarro", 30113444, "Mediocampista", new DateTime(1994, 6, 13)),
            new CJugador("Kevin", "Serrano", 30113555, "Delantero", new DateTime(1991, 9, 7)),
            new CJugador("Lautaro", "Villalba", 30113666, "Defensor", new DateTime(2002, 7, 28)),
            new CJugador("Micaela", "Roldán", 30113777, "Mediocampista", new DateTime(1993, 12, 6)),
            new CJugador("Noelia", "Castillo", 30113888, "Delantero", new DateTime(1997, 1, 23)),
            new CJugador("Oscar", "Paz", 30113999, "Defensor", new DateTime(1995, 5, 15)),
            new CJugador("Pablo", "Quiroga", 30114000, "Arquero", new DateTime(1990, 3, 3)),
            new CJugador("Ramón", "Silva", 30114111, "Delantero", new DateTime(1999, 10, 19)),
            new CJugador("Sabrina", "Domínguez", 30114222, "Defensor", new DateTime(1996, 8, 14)),
            new CJugador("Tobías", "Espinosa", 30114333, "Mediocampista", new DateTime(2000, 11, 2)),
            new CJugador("Ulises", "Correa", 30114444, "Defensor", new DateTime(1991, 4, 25)),
        };

        foreach (var jugador in jugadores)
            controlador.AgregarJugadorDesdeForm(jugador);

        // EQUIPOS
        controlador.CrearEquipoDesdeForm("EQ001", "Los Tigres", "Rojo y Negro", 12345678);
        controlador.CrearEquipoDesdeForm("EQ002", "Las Panteras", "Negro y Blanco", 23456789);
        controlador.CrearEquipoDesdeForm("EQ003", "Águilas Doradas", "Amarillo y Azul", 34567890);
        controlador.CrearEquipoDesdeForm("EQ004", "Furia Verde", "Verde y Negro", 45678901);

        // Asociación de jugadores a cada equipo (11 por equipo, mínimo)
        var equipos = controlador.ObtenerEquipos();

        var todos = controlador.ObtenerJugadores();
        int jugadorIndex = 0;

        foreach (var equipo in equipos)
        {
            int agregados = 0;
            while (agregados < 11 && jugadorIndex < todos.Count)
            {
                if (equipo.AgregarJugador(todos[jugadorIndex]))
                    agregados++;
                jugadorIndex++;
            }
        }
    }
}
