using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
    public class Pessoa
    {
        public Guid PessoaId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Telefone> Telefone { get; set; }
    }
}
