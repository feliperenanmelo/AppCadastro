using Confitec.Cadastro.Models.Base;
using System.Collections.Generic;

namespace Confitec.Cadastro.Models
{
    public class Escolaridade : Entity
    {   
        public string Descricao { get; set; }

        public static List<Escolaridade> ObterTodas()
        {
            return new List<Escolaridade>()
            {
                new Escolaridade() { Id = 1, Descricao = "Infántil"},
                new Escolaridade() { Id = 2, Descricao = "Fundamental"},
                new Escolaridade() { Id = 3, Descricao = "Médio"},
                new Escolaridade() { Id = 4, Descricao = "Superior"},
            };
        }

        public static bool Existir(int id)
        {
            return ObterTodas().Exists(e => e.Id == id);
        }
    }
}
