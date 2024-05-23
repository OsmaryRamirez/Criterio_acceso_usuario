using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datoss;
using Capa_Entidadaa;

namespace Capa_Negocioo
{
    
    
    public class Nusuario
    {
        Dusuario obj = new Dusuario();
        public DataTable nusuario(Eusuarios obje)

        {

            return obj.conexion(obje);
        }
    }
}
