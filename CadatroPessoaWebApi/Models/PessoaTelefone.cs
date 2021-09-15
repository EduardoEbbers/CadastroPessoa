using System;
using System.Collections.Generic;

namespace CadatroPessoaWebApi.Models
{
    public partial class PessoaTelefone
    {
        public int IdPessoa { get; set; }
        public int IdTelefone { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Telefone Telefone { get; set; }
    }
}
