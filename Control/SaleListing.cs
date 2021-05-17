using System;

namespace Control
{
    public class SaleListing
    {
        public int ID_Venda { get; set; }
        public DateTime DT_Venda { get; set; }
        public string NM_Cliente { get; set; }
        public string  NM_Funcionario { get; set; }
        public string VL_Custo { get; set; }

        public string NM_Produto { get; set; }
        public string VL_Total { get; set; }
        public double VL_TotalD { get; set; }


    }
}