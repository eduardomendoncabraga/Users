using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserDomain.Entities;

namespace UserInfra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<UserContact> UserContact { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        public DbSet<UserEmail> UserEmail { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<EmailType> EmailType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // foreach (var property in modelBuilder.Model.GetEntityTypes()
            //     .SelectMany(e => e.GetProperties()
            //         .Where(p => p.ClrType == typeof(string))))
            //     property.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}