using Library.Entities;
using Library.Models;
using Library.Models.Request;
using Library.Models.Response;
using System;

namespace Service.IServices
{
    public interface IPessoaService
    {
        PagedQueries<PessoaResponse> GetPessoas(PessoaRequest request);

        Pessoa GetPessoaById(Guid pessoaId);
    }
}
