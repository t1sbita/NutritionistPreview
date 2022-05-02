using Microsoft.EntityFrameworkCore;
using NutritionistPreview.Api.Core.Util;
using System.Reflection;

namespace NutritionistPreview.Api.Infrastructure.Data.Context
{
    public class NutritionistContext : BaseContext
    {
        public NutritionistContext(DbContextOptions<NutritionistContext> options) : base(options)
        {
        }

        public NutritionistContext() : base()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string schema = SecretsUtil.GetSchema();
            modelBuilder.HasDefaultSchema(schema);
            
            var typesToRegister = from t in Assembly.GetExecutingAssembly().GetTypes()
                                  where !string.IsNullOrWhiteSpace(t.Namespace) &&
                                  t.GetInterfaces().Any(i => i.Name == typeof(IEntityTypeConfiguration<>).Name && i.Namespace == typeof(IEntityTypeConfiguration<>).Namespace)
                                  select t;

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
