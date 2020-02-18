using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Response
{
    public class DetalhesPessoaResponse
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public virtual List<TelefoneResponse> Telefone { get; set; }
    }
}
