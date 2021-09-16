using CadatroPessoaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories.Dto
{
    public class PessoaDto
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int IdEndereco { get; set; }

        public Pessoa ParseToObject()
        {
            return new Pessoa(IdPessoa, Nome, Cpf, IdEndereco);
        }
    }
}
