using Microsoft.EntityFrameworkCore;
using Piramida.Storage.Models;

namespace Piramida.Storage.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Product_property> Product_properties { get; set; }

        public virtual DbSet<Admission> Admissions { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Cart_product> Cart_products { get; set; }

        public virtual DbSet<Cart_additional_admission> Cart_Additional_Admissions { get; set; }

        public virtual DbSet<Cart_additional_property> Cart_Additional_Properties { get; set; }

        public virtual DbSet<Season_ticket_properties> Season_Ticket_Properties { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Feedback> Feedbacks { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<ImagesForSpailn> ImagesForSpailns { get; set; }

        public virtual DbSet<Sale_product_property> Sale_Product_Properties { get; set; }

        public virtual DbSet<Season_ticket> Season_tickets { get; set; }
    }
}
