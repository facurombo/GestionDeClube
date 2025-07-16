using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiondeclubesform
{
    internal interface IParticipante
    {
        int CodigoIdentificacion { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }

        string DarDatos();

    }
}
