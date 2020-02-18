using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library
{
    public class Telefone
    {
        public Guid TelefoneId { get; set; }

        [Required]
        public Guid PessoaId { get; set; }

        [Required]
        [MaxLength(11)]
        public int Numero { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
