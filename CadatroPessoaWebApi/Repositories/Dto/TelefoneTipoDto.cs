using CadatroPessoaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories.Dto
{
    public class TelefoneTipoDto
    {
        public int IdTelefoneTipo { get; set; }
        public string Tipo { get; set; }

        public TelefoneTipo ParseToObject()
        {
            return new TelefoneTipo(IdTelefoneTipo, Tipo);
        }
    }
}
