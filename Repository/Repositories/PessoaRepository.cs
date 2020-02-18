using Library.Entities;
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

        public Pessoa GetPessoaById(Guid pessoaId)
        {
            try
            {
                return _context.Pessoa
                               .Include(x => x.Telefone)
                               .AsNoTracking()
                               .FirstOrDefault(x => x.PessoaId.Equals(pessoaId));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar detalhes da pessoa", ex);
            }
        }

        public PagedQueries<PessoaResponse> GetPessoas(int pageSize, int pageIndex, int minimoTelefones)
        {
            try
            {
                var query = _context.Pessoa.Select(x => new PessoaResponse
                {
                    PessoaId = x.PessoaId,
                    DataNascimento = x.DataNascimento,
                    Nome = x.Nome,
                    QuantidadeTelefones = _context.Telefone.Where(y => y.PessoaId.Equals(x.PessoaId)).Count()
                }).Where(x => x.QuantidadeTelefones > minimoTelefones).AsNoTracking();

                return PagedQueries<PessoaResponse>.Create(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar pessoas", ex);
            }
        }
    }
}
