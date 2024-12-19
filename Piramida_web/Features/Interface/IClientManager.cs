using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Client;

namespace Piramida_web.Features.Interface
{
    public interface IClientManager
    {
        public void Creat(EditClientDto editClient);
        public void Update(EditClientDto editClient);
        public void Delete(Guid Id);
        public ClientDto GetClient(Guid Id);
        public ClientDto[] GetListClient(ClientFilterDto clientFilter);
    }
}
