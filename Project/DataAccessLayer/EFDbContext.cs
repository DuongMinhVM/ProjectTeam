using EntityLayer;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class EfDbContext : IdentityDbContext<UserEntity>
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderItemEntity> OrdersItems { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<MerchantEntity> Merchants { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        public EfDbContext() : base(
            "Data Source=10.211.55.2;Initial Catalog=ProjectTeam; Persist Security Info=True;User ID=SA;Password=Vmdvmd123;MultipleActiveResultSets=True")
        {
        }

        public static EfDbContext Create()
        {
            return new EfDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}