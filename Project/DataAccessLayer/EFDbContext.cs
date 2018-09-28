using EntityLayer;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class EFDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderItemEntity> OrdersItems { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<MerchantEntity> Merchants { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CatagoryEntity> Catagories { get; set; }

        public EFDbContext() : base("Data Source=10.211.55.2;Initial Catalog=ProjectTeam; Persist Security Info=True;User ID=SA;Password=Vmdvmd123;MultipleActiveResultSets=True")
        {
        }

        public static EFDbContext Create()
        {
            return new EFDbContext();
        }
    }
}