using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using App.Entities.Business;

namespace App.Data.Implements.Context
{
    public sealed class DataContext : DbContext
    {
        public DataContext()
            : base("ConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<User> User { get; set; }
    }
}
