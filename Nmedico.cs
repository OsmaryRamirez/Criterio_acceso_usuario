using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidadaa;
using Capa_Datoss;

namespace Capa_Negocioo
{
    public class Nmedico
    {

        public static DataTable ListarMedicos(string valor)
        {
            Dmedico datos = new Dmedico();
            return datos.ListarMedicos(valor);
        }
        public static DataTable BuscarMedicos(string valor)
        {
            Dmedico datos = new Dmedico();
            return datos.BuscarMedico(valor);
        }
        public static string GuardarMedico(int opcion, Emedico datos)
        {
            Dmedico dat = new Dmedico();
            return dat.GuardarMedico(opcion, datos);
        }
    }
}
