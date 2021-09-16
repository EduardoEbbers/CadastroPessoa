using CadatroPessoaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories.Dto
{
    public class PessoaTelefoneDto
    {
        //talvez vai ter q excluir
        public int IdPessoa { get; set; }
        public int IdTelefone { get; set; }

        public PessoaTelefone ParseToObject()
        {
            return new PessoaTelefone(IdPessoa, IdTelefone);
        }
    }
}
