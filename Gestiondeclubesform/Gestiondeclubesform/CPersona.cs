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
    public class CPersona //socios
    {

        public string Nombre { get; private set; }

        public string Apellido { get; private set; }
        public int DNI { get; private set; }


        public CPersona(string nombre, string apellido, int dni) 
        {
            this.Nombre = nombre;
            this.DNI = dni;
            this.Apellido = apellido;
        }





    }
}
