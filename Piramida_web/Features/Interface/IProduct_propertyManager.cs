using Piramida.Logic.DtoModels.Filters;
using Piramida_web.Features.DtoModels.Product_property;

namespace Piramida_web.Features.Interface
{
    public interface IProduct_propertyManager
    {
        public void Creat(EditProduct_propertyDto editProduct_property);
        public void Update(EditProduct_propertyDto editProduct_property);
        public void Delete(Guid Id);
        public Product_propertyDto GetProduct_property(Guid Id);
        public Product_propertyDto[] GetListProduct_property(Product_propertyFilterDto product_propertyFilter);

        public Product_propertyDto[] GetListProduct_propertyByProduct(Product_propertyByProductFilterDto product_propertyByProduct);
    }
}
