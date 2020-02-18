using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library
{
    public class Pessoa
    {
        public Guid PessoaId { get; set; }

        [Required]
        [MaxLength(200)]
        public int Nome { get; set; }

        [Required]
        public int DataNascimento { get; set; }

        public virtual ICollection<Telefone> Telefone { get; set; }
    }
}
