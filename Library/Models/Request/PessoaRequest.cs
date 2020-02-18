using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.Request
{
    public class PessoaRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PageIndex { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }

        [Required]
        public bool MaisQueUmTelefone { get; set; }
    }
}
