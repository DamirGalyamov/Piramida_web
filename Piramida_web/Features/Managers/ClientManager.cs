using AutoMapper;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Database;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Client;
using Piramida_web.Features.Interface;

namespace Piramida_web.Features.Managers
{
    public class ClientManager : IClientManager
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IClientService _clientServices;
        private readonly DataContext _dataContext;

        public ClientManager(IClientRepository clientRepository, IClientService clientServices, DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _clientServices = clientServices;
            _dataContext = dataContext;
        }

        public void Creat(EditClientDto editClient)
        {
            var Clients = _mapper.Map<Client>(editClient);

            //System.Console.WriteLine($"Случайный Guid: {Client.Id}");

            _clientRepository.Create(_dataContext, Clients);

            _dataContext.SaveChanges();

        }

        public void Update(EditClientDto editClient)
        {
            var Client = _mapper.Map<Client>(editClient);

            _clientRepository.Update(_dataContext, Client);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            _clientRepository.Delete(_dataContext, Id);
            _dataContext.SaveChanges();
        }

        public ClientDto GetClient(Guid Id)
        {
            var client = _clientRepository.GetByID(_dataContext, Id);
            return _mapper.Map<ClientDto>(client);
        }

        public ClientDto[] GetListClient(ClientFilterDto clientFilter)
        {
            var client = _clientServices.GetClientQueryable(_dataContext, clientFilter, true)
                .Select(x => new ClientDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Telephone = x.Telephone,
                    Login = x.Login,
                    Email = x.Email,
                    Password = x.Password

                }).ToArray();
            return client;
        }
    }
}
