using AutoMapper;
using CakeShop.Core.Dto;
using CakeShop.Core.Models;

namespace CakeShop.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VendaDetalhes, Order>();
            CreateMap<JogoDetalhes, Jogo>();

            CreateMap<Jogo, JogoDetalhes>();
        }
    }
}
