
using AutoMapper;
using Cobrancas.Application.Models;
using Cobrancas.Domain.Entities;

namespace Clientes.Application.Mappings
{
    public class MappingsCobraca : Profile
    {
        public MappingsCobraca()
        {
            CreateMap<CreateCobrancaRequest, Cobranca>()
                .ForMember(d => d.CPF, map =>
                    map.MapFrom(s => s.CPF.Replace(".", "").Replace("-", ""))
            );

            CreateMap<CobrancaRequest, Cobranca>()
                .ForMember(d => d.CPF, map =>
                    map.MapFrom(s => s.CPF.Replace(".", "").Replace("-", ""))
            );

            CreateMap<Cobranca, CobrancaResponse>()
                .ForMember(d => d.CPF, map =>
                    map.MapFrom(s => s.CPF.Replace(".", "").Replace("-", ""))
            );
        }

    }
}