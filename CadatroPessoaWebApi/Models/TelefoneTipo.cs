﻿using System;
using System.Collections.Generic;

namespace CadatroPessoaWebApi.Models
{
    public partial class TelefoneTipo
    {
        public TelefoneTipo()
        {
            Telefone = new HashSet<Telefone>();
        }

        public int IdTelefoneTipo { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Telefone> Telefone { get; set; }
    }
}
