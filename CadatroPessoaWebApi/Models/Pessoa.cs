using System;
using System.Collections.Generic;

namespace CadatroPessoaWebApi.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            PessoaTelefone = new HashSet<PessoaTelefone>();
        }

        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public int IdEndereco { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<PessoaTelefone> PessoaTelefone { get; set; }
    }
}
