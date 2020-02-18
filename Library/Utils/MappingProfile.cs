using AutoMapper;
using Library.Entities;
using Library.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pessoa, DetalhesPessoaResponse>();
            CreateMap<Telefone, TelefoneResponse>();
        }
    }
}
