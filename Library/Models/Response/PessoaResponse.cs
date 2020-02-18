using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.Response
{
    public class PessoaResponse
    {
        public Guid PessoaId { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
