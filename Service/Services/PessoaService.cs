using Library.Models;
using Library.Models.Request;
using Library.Models.Response;
using Repository.IRepositories;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class PessoaService : IPessoaService
    {
		private readonly IPessoaRepository _pessoaRepository;
		public PessoaService(IPessoaRepository pessoaRepository)
		{
			_pessoaRepository = pessoaRepository;
		}

        public PagedQueries<PessoaResponse> GetPessoas(PessoaRequest request)
        {
			try
			{
				if (request == null)
				{
					throw new Exception("Dados não fornecidos corretamente");
				}

				return _pessoaRepository.GetPessoas(request.PageIndex, request.PageSize);
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
