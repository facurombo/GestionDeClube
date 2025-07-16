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
    public class CEntrenador : IParticipante
    {

        public int CodigoIdentificacion { get; set; }

        public int Telefono {get; private set; }

        public List<CEquipo> Equipos {get; private set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public CEntrenador (string nombre, string apellido, int dni, int telefono) 
        
        {
            
            this.Telefono = telefono;
            this.CodigoIdentificacion = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            
            Equipos = new List<CEquipo>();
        }

        public void DirigirEquipo (CEquipo equipo)
        {
            if (!Equipos.Contains(equipo))
            {
                Equipos.Add(equipo);
            }
        }

        public string ObtenerEquipos()
        {
            if (Equipos.Count == 0)
            {
                return "No dirige ningún equipo.";
            }
            return string.Join(", ", Equipos.Select(e => e.NombreEquipo));
        }

        public string NombreCompleto
        {
            get { return $"{CodigoIdentificacion} - {Nombre} {Apellido}"; }
        }

        public override string ToString()
        {
            return NombreCompleto;
        }

        public string DarDatos()
        {
            return NombreCompleto;   
        }



    }
}
