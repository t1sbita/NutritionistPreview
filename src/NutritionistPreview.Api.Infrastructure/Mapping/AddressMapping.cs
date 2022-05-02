using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionistPreview.Api.Core.Domain.Entities;

namespace NutritionistPreview.Api.Infrastructure.Mapping
{
    internal class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.DescriptionAddress).HasColumnName("DescriptionAddress");
            builder.Property(x => x.Number).HasColumnName("Number");
            builder.Property(x => x.ZipCode).HasColumnName("ZipCode");
            builder.Property(x => x.City).HasColumnName("City");
            builder.Property(x => x.State).HasColumnName("State");
        }

    }
}
