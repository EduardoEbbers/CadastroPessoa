﻿using System;
using System.Collections.Generic;

namespace CadatroPessoaWebApi.Models
{
    public partial class Telefone
    {
        public Telefone()
        {
            PessoaTelefone = new HashSet<PessoaTelefone>();
        }

        public int IdTelefone { get; set; }
        public int Numero { get; set; }
        public int Ddd { get; set; }
        public int IdTelefoneTipo { get; set; }

        public virtual TelefoneTipo TelefoneTipo { get; set; }
        public virtual ICollection<PessoaTelefone> PessoaTelefone { get; set; }
    }
}
