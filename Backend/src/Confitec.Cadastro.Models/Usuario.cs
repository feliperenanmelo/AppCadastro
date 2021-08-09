using Confitec.Cadastro.Models.Base;
using System;

namespace Confitec.Cadastro.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Escolaridade { get; set; }


        public static bool ValidarDataNascimentoInvalida(DateTime data)
        {
            var value = DateTime.Compare(data, DateTime.Now.Date);            

            return value > 0;
        }
    }
}
