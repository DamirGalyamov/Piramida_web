using Microsoft.Extensions.DependencyInjection;
using Piramid.Logic.Interfaces.Repositories;
using Piramid.Logic.Interfaces.Services;
using Piramid.Logic.Repositories;
using Piramid.Logic.Services;

namespace Piramida.Logic.Extations;

public static class ServiceCollectionsExtentions
{
    public static void AddLogicServices(this IServiceCollection services)
    {
        services.AddSingleton<IAdmissionService, AdmissionService>();
        services.AddSingleton<IClientService, ClientService>();
        services.AddSingleton<ICartService, CartService>();
        services.AddSingleton<ICart_additional_admissionService, Cart_additional_admissionService>();
        services.AddSingleton<ICart_additional_propertyService, Cart_additional_propertyService>();
        services.AddSingleton<ICart_productService, Cart_productService>();
        services.AddSingleton<IEmployeeService, EmployeeService>();
        services.AddSingleton<IImageForSplainService, ImageForSplainService>();
        services.AddSingleton<IFeedbackService, FeedbackService>();
        services.AddSingleton<IProduct_propertyService, Product_propertyService>();
        services.AddSingleton<IProductService, ProductService>();
        services.AddSingleton<ISaleService, SaleService>();
        services.AddSingleton<ISale_product_propertyService, Sale_product_propertyService>();
        services.AddSingleton<ISeason_ticketService, Season_ticketService>();
        services.AddSingleton<ISeason_ticket_propertiesService, Season_ticket_propertiesService>();
        services.AddSingleton<IAdmissionRepository, AdmissionRepository>();
        services.AddSingleton<IClientRepository, ClientRepository>();
        services.AddSingleton<ICartRepository, CartRepository>();
        services.AddSingleton<ICart_additional_admissionRepository, Cart_additional_admissionRepository>();
        services.AddSingleton<ICart_additional_propertyRepository, Cart_additional_propertyRepository>();
        services.AddSingleton<ICart_productRepository, Cart_productRepository>();
        services.AddSingleton<IFeedbackRepository, FeedbackRepository>();
        services.AddSingleton<IImageForSplainRepository, ImageForSplainRepository>();
        services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
        services.AddSingleton<IProduct_propertyRepository, Product_propertyRepository>();
        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<ISaleRepository, SaleRepository>();
        services.AddSingleton<ISale_product_propertyRepository, Sale_product_propertyRepository>();
        services.AddSingleton<ISeason_ticketRepository, Season_ticketRepository>();
        services.AddSingleton<ISeason_ticket_propertiesRepository, Season_ticket_propertiesRepository>();
    }
}
