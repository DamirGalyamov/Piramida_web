using AutoMapper;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Client;

namespace Piramida_web.Features.Mappers
{
    public class ClientMapper : Profile
    {
        public ClientMapper()
        {
            CreateMap<ClientDto, Client>();
            CreateMap<Client, ClientDto>();

            CreateMap<ClientDto[], Client[]>();
            CreateMap<Client[], ClientDto[]>();

            CreateMap<EditClientDto, Client>();
            CreateMap<Client, EditClientDto>();
        }
    }
}
