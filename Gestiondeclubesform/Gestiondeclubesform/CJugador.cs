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
    public class CJugador : IParticipante
    {

        public int CodigoIdentificacion { get; set; }

        public DateTime Nacimiento { get; private set; }
        public string Posicion { get; private set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }





        public CJugador (string nombre, string Apellido, int DNI,  string posicion, DateTime naci ) 
        
        {
            this.Posicion = posicion;
            this.Nacimiento = naci;
            this.CodigoIdentificacion = DNI;
            this.Nombre = nombre;
            this.Apellido = Apellido;

        }

        public int Edad => DateTime.Now.Year - Nacimiento.Year;

        public string NombreCompleto => $"{CodigoIdentificacion} - {Nombre} {Apellido}";

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
