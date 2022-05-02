using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionistPreview.Api.Core.Domain.Entities;
using NutritionistPreview.Api.Core.Util;

namespace NutritionistPreview.Api.Infrastructure.Mapping
{
    internal class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.DocumentNumber).HasColumnName("DocumentNumber");
            builder.Property(x => x.BirthDate).HasColumnName("BirthDate");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.TelephoneNumber).HasColumnName("TelephoneNumber");
            builder.Property(x => x.AddressId).HasColumnName("AddressId");

            //builder.HasOne(c => c.Address).WithOne().HasForeignKey<Client>(c => c.AddressId);
            builder.HasMany(c => c.Appointments).WithOne(a => a.Client).HasForeignKey(c => c.ClientId);
        }

    }
}
