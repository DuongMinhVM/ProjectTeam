using System.Data.Entity;
using EntityLayer;

namespace DataAccessLayer
{
    public class EfDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderItemEntity> OrdersItems { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<MerchantEntity> Merchants { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        private EfDbContext() : base("Data Source=10.211.55.2;Initial Catalog=ProjectTeam; Persist Security Info=True;User ID=SA;Password=Vmdvmd123;MultipleActiveResultSets=True")
        {
        }

        public static EfDbContext Create()
        {
            return new EfDbContext();
        }
    }
}