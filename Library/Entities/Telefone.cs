using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
    public class Telefone
    {
        public Guid TelefoneId { get; set; }

        [Required]
        public Guid PessoaId { get; set; }

        [Required]
        [MaxLength(11)]
        public string Numero { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
