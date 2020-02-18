using Library.Entities;
using Library.Models;
using Library.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.IRepositories
{
    public interface IPessoaRepository
    {
        PagedQueries<PessoaResponse> GetPessoas(int pageSize, int pageIndex, int minimoTelefones);

        Pessoa GetPessoaById(Guid pessoaId);
    }
}
