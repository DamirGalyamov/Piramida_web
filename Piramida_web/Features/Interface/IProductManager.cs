using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Product;

namespace Piramida_web.Features.Interface
{
    public interface IProductManager
    {
        public void Creat(EditProductDto editProduct);
        public void Update(EditProductDto editProduct);
        public void Delete(Guid Id);
        public ProductDto GetProduct(Guid Id);
        public ProductDto[] GetListProduct(ProductFilterDto productFilter);
    }
}
