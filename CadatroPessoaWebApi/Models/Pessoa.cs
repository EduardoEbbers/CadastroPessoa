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

        public Pessoa(int idPessoa, string nome, string cpf, int idEndereco)
        {
            this.IdPessoa = idPessoa;
            this.Nome = nome;
            this.Cpf = cpf;
            this.IdEndereco = idEndereco;
        }

        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int IdEndereco { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<PessoaTelefone> PessoaTelefone { get; set; }
    }
}
