using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class ControlNivelAcesso
    {
        ModelNivelAcesso myNivelAcesso;

        // Metodo Mostrar
        public DataTable MostrarNivelAcesso()
        {
            myNivelAcesso = new ModelNivelAcesso();
            return myNivelAcesso.MostrarNivelAcesso();
        }
    }
}
