using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FKTest.Models
{
    class FkDbContext : DbContext
    {
        public FkDbContext(DbContextOptions<FkDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type[] types = typeof(FkDbContext).GetTypeInfo().Assembly.GetTypes();
            IEnumerable<Type> typesToRegister = types
                .Where(type => type.GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Any(i => i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                addConfiguration(modelBuilder, configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        private static void addConfiguration<TEntity>(ModelBuilder modelBuilder, IEntityTypeConfiguration<TEntity> configuration)
            where TEntity : class
        {
            configuration.Configure(modelBuilder.Entity<TEntity>());
        }
    }
}
