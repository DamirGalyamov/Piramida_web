using Piramida.Logic.Extations;
using Piramida_web.Features.Filters;
using Piramida_web.Features.Interface;
using Piramida_web.Features.Managers;
using Piramida_web.Features.Mappers;

namespace Piramida_web.Extensions
{
    public static class ServiceCollectionExtention
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddLogicServices();

            services.AddTransient<IAdmissionManager, AdmissionManager>();
            services.AddTransient<IClientManager, ClientManager>();
            services.AddTransient<ICartManager, CartManager>();
            services.AddTransient<ICart_additional_admissionManager, Cart_additional_admissionManager>();
            services.AddTransient<ICart_additional_propertyManager, Cart_additional_propertyManager>();
            services.AddTransient<ICart_productManager, Cart_productManager>();
            services.AddTransient<IEmployeeManager, EmployeeManager>();
            services.AddTransient<IImagesForSpailnManager, ImagesForSpailnManager>();
            services.AddTransient<IFeedbackManager, FeedbackManager>();
            services.AddTransient<IProduct_propertyManager, Product_propertyManager>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<ISaleManager, SaleManager>();
            services.AddTransient<ISale_product_propertyManager, Sale_product_propertyManager>();
            services.AddTransient<ISeason_ticketManager, Season_ticketManager>();
            services.AddTransient<ISeason_ticket_propertiesManager, Season_ticket_propertiesManager>();
            services.AddScoped<DevelopmentOnlyFilter>();

        }
        public static void AddAutoMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(AdmissionMapper),
                typeof(ClientMapper),
                typeof(CartMapper),
                typeof(Cart_additional_admissionMapper),
                typeof(Cart_additional_propertyMapper),
                typeof(Cart_productMapper),
                typeof(EmployeeMapper),
                typeof(ImagesForSpailnMapper),
                typeof(FeedbackMapper),
                typeof(Product_propertyMapper),
                typeof(ProductMapper),
                typeof(SaleMapper),
                typeof(Sale_product_propertyMapper),
                typeof(Season_ticket_propertiesMapper),
                typeof(Season_ticketMapper));
        }

    }
}
