using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public class Validar
    {


        public bool CampoValido { get; set; }
        public bool TamanhoValido { get; set; }
        public bool LetraValida { get; set; }
        public bool NumeroValido { get; set; }
        public DateTime? DtNascimento { get; set; }
        public bool ValorValido { get; set; }
        public bool DtNascimentoValido { get; set; }
        public bool SenhaValida { get; set; }
        public bool UsuarioValido { get; set; }
        public bool SenhaOk { get; set; }






        public Validar()
        {

        }

        public bool CampoNulo(string campo)
        {
            if (campo == string.Empty)
            {
                CampoValido = false;
            }
            else
            {
                CampoValido = true;
            }

            return CampoValido;
        }

        public bool TamanhoCampo(string campo, int tamanho)
        {
            if (campo.Length > tamanho)
            {
                TamanhoValido = false;
            }
            else
            {
                TamanhoValido = true;
            }

            return TamanhoValido;
        }

        public bool Letra(string campo)
        {
            if (!Regex.IsMatch(campo, @"^[a-zA-Z\s]+$"))
            {
                LetraValida = false;
            }
            else
            {
                LetraValida = true;
            }

            return LetraValida;
        }

        public bool Numero(string campo)
        {
            if (!Regex.IsMatch(campo, @"^[\d]+$"))
            {
                NumeroValido = false;
            }
            else
            {
                NumeroValido = true;
            }

            return NumeroValido;
        }

        public bool Valor(string campo)
        {
            if (!Regex.IsMatch(campo, @"^[1-9]\d{0,2}(\.\d{3})*,\d{2}$"))
            {
                ValorValido = false;
            }
            else
            {
                ValorValido = true;
            }

            return ValorValido;
        }

        public bool ValorKg(string campo)
        {
            //  if (!Regex.IsMatch(campo, @"^[1-9]\d{0,3}(\\d{3})*$"))

            if (!Regex.IsMatch(campo, @"^[1-9]\d{0,2}(\.\d{3})*,\d{2}$"))
            {
                ValorValido = false;
            }
            else
            {
                ValorValido = true;
            }

            return ValorValido;
        }

        public bool ValorComZero(string campo)
        {
            if (!Regex.IsMatch(campo, @"^[\d]\d{0,2}(\.\d{3})*,\d{2}$"))
            {
                ValorValido = false;
            }
            else
            {
                ValorValido = true;
            }

            return ValorValido;
        }

        public void DataNascimento(DateTimePicker campo)
        {
            if (campo.Value >= campo.MaxDate)
            {
                DtNascimento = null;
            }
            else
            {
                DtNascimento = campo.Value;
            }
        }

        public void DataNascimentoObrigatorio(DateTimePicker campo)
        {
            if (campo.Value >= campo.MaxDate)
            {
                DtNascimentoValido = false;
            }
            else
            {
                DtNascimentoValido = true;
            }
        }

        public bool UsuarioVazio(string campo)
        {
            if (campo == "USUÁRIO")
            {
                UsuarioValido = false;
            }
            else
            {
                UsuarioValido = true;
            }

            return UsuarioValido;
        }

        public bool SenhaVazia(string campo)
        {
            if (campo == "SENHA")
            {
                SenhaValida = false;
            }
            else
            {
                SenhaValida = true;
            }

            return SenhaValida;
        }
        public bool SenhaCompleta(string campo)
        {
            int count = 0;
            foreach (char c in campo)
            {
                count++;

            }
            if (count < 8)
            {
                SenhaOk = false;
            }
            else
            {
                SenhaOk = true;
            }



            int maiusculas = campo.Count(char.IsUpper);
            
            if(maiusculas < 1)
            {
                SenhaValida = false;
            }

          

        

            return SenhaValida;
        }

        public bool ValidaCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 ||
                cpf == "00000000000" ||
                cpf == "11111111111" ||
                cpf == "22222222222" ||
                cpf == "33333333333" ||
                cpf == "44444444444" ||
                cpf == "55555555555" ||
                cpf == "66666666666" ||
                cpf == "77777777777" ||
                cpf == "88888888888" ||
                cpf == "99999999999")
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
