using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Models.Request;
using Library.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoasController(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost]
        public IActionResult GetPessoas([FromBody] PessoaRequest request)
        {
            try
            {
                var result = _pessoaService.GetPessoas(request);

                var paginationResponse = new PaginationResponse<PessoaResponse>
                {
                    ItemsList = result,
                    PageIndex = result.PageIndex,
                    TotalItens = result.TotalItens,
                    TotalPages = result.TotalPages
                };

                return Ok(paginationResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet("{pessoaId}")]
        public IActionResult GetPessoaById([FromRoute] Guid pessoaId)
        {
            try
            {
                return Ok(_mapper.Map<DetalhesPessoaResponse>(_pessoaService.GetPessoaById(pessoaId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}