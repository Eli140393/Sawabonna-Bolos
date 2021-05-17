using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelPessoa
    {
        private int _ID;
        private string _Nome;
        private string _Sexo;
        private string _CPF;
        private DateTime? _DataNascimento;
        private string _Telefone;
        private string _Email;
        private string _CEP;
        private string _Rua;
        private string _NumCasa;
        private string _Bairro;
        private string _Complemento;
        private string _Cidade;
        private string _Estado;

        public int ID { get => _ID; set => _ID = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string CPF { get => _CPF; set => _CPF = value; }
        public DateTime? DataNascimento { get => _DataNascimento; set => _DataNascimento = value; }
        public string Telefone { get => _Telefone; set => _Telefone = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string CEP { get => _CEP; set => _CEP = value; }
        public string Rua { get => _Rua; set => _Rua = value; }
        public string NumCasa { get => _NumCasa; set => _NumCasa = value; }
        public string Bairro { get => _Bairro; set => _Bairro = value; }
        public string Complemento { get => _Complemento; set => _Complemento = value; }
        public string Cidade { get => _Cidade; set => _Cidade = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        public ModelPessoa()
        {

        }
    }
}
