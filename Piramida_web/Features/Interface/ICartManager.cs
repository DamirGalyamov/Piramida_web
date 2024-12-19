using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Cart;

namespace Piramida_web.Features.Interface
{
    public interface ICartManager
    {
        public CartDto Creat(EditCartDto editCart);
        public void Update(EditCartDto editCart);
        public void Delete(Guid Id);
        public CartDto GetCart(Guid Id);
        public CartDto[] GetListCart(CartFilterDto clientFilter);
        public CartDto[] GetListCartByClient(CartFilterDto cartFilter);
    }
}
