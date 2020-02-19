using Library.Entities;
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

        public Pessoa GetPessoaById(Guid pessoaId)
        {
            try
            {
                if (pessoaId == Guid.Empty)
                {
                    throw new ArgumentNullException(string.Format("Dados não informados para a operação", pessoaId));
                }

                var pessoa = _pessoaRepository.GetPessoaById(pessoaId);

                if (pessoa == null)
                {
                    throw new Exception("Pessoa não encontrada");
                }

                return pessoa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PagedQueries<PessoaResponse> GetPessoas(PessoaRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new Exception("Dados não fornecidos corretamente");
                }

                int minimoTelefones = 0;
                if (request.MaisQueUmTelefone)
                {
                    minimoTelefones += 2;
                }

                return _pessoaRepository.GetPessoas(request.PageSize, request.PageIndex, minimoTelefones);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
