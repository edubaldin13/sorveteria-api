using AutoMapper;
using Microsoft.Win32;
using Sorveteria.DTO;
using Sorveteria.DTO.Requests;
using Sorveteria.DTO.Responses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sorveteria.Configs.Automapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //adicionar os CreateMap(Entidade, Dto)
            //adicionar os CreateMap(Entidade, Request)
            CreateMap<Sabor, GetSaboresResponse>().ReverseMap();
            CreateMap<Pedido, GetPedidosResponse>().ReverseMap();
            CreateMap<Pedido, PedidosPostRequest>().ReverseMap();
            CreateMap<Pedido, GetPedidosResponse>().ForMember(dest => dest.Sabor1, opt => opt.MapFrom(src => src.Sabor1));
            CreateMap<Pedido, GetPedidosResponse>().ForMember(dest => dest.Sabor2, opt => opt.MapFrom(src => src.Sabor2));

        }
    }
}
