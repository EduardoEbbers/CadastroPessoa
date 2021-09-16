using CadatroPessoaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories.Dto
{
    public class TelefoneDto
    {
        public int IdTelefone { get; set; }
        public int Numero { get; set; }
        public int Ddd { get; set; }
        public int IdTelefoneTipo { get; set; }

        public Telefone ParseToObject()
        {
            return new Telefone(IdTelefone, Numero, Ddd, IdTelefoneTipo);
        }
    }
}
