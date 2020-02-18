using Library.Models;
using Library.Models.Request;
using Library.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface IPessoaService
    {
        PagedQueries<PessoaResponse> GetPessoas(PessoaRequest request);
    }
}
