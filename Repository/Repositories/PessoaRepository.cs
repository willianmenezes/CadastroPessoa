using Library.Models;
using Library.Models.Response;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.IRepositories;
using Repository.Repositories;
using System;
using System.Linq;

namespace Repository.Repository
{
    public class PessoaRepository : BaseRepository, IPessoaRepository
    {
        public PessoaRepository(Context context) : base(context) { }
        public PagedQueries<PessoaResponse> GetPessoas(int pageSize, int pageIndex)
        {
            try
            {
                var query = _context.Pessoa.Select(x => new PessoaResponse
                {
                    PessoaId = x.PessoaId,
                    DataNascimento = x.DataNascimento,
                    Nome = x.Nome
                }).AsNoTracking();

                return PagedQueries<PessoaResponse>.Create(query, pageSize, pageIndex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar pessoas", ex);
            }
        }
    }
}
