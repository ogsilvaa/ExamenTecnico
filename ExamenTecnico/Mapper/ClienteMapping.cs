using AutoMapper;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenTecnico.Mapper
{
    public class ClienteMapping:Profile
    {
        public ClienteMapping()
        {
            CreateMap<ClientePost, Cliente>();
            CreateMap<Cliente, ClienteList>()
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.Apellidos}, {src.Nombres}"));
        }
    }
}
