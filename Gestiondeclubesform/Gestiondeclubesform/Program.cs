using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// Grupo: 3
// Fermin Regidor
// 29653
// Facundo Ezequiel Rombola
// 30253 

namespace Gestiondeclubesform
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

                Application.EnableVisualStyles();
            
            
            Application.SetCompatibleTextRenderingDefault(false);

            var controlador = new CControladorTorneo();


            DatosDePrueba.Cargar(controlador);
            Application.Run(new Ingreso(controlador));
        }
    }
}
