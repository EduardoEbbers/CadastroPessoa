using CadatroPessoaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories.Dto
{
    public class EnderecoDto
    {
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco ParseToObject()
        {
            return new Endereco(IdEndereco, Logradouro, Numero, Cep, Bairro, Cidade, Estado);
        }
    }
}
