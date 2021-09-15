using System;
using System.Collections.Generic;

namespace CadatroPessoaWebApi.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Pessoa = new HashSet<Pessoa>();
        }

        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Pessoa> Pessoa { get; set; }
    }
}
