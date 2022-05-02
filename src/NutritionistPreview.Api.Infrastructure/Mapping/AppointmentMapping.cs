using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutritionistPreview.Api.Core.Domain.Entities;

namespace NutritionistPreview.Api.Infrastructure.Mapping
{
    internal class AppointmentMapping : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.DatePerformed).HasColumnName("DatePerformed");
            builder.Property(x => x.BodyFatPercent).HasColumnName("BodyFatPercent");
            builder.Property(x => x.PhysicalSensation).HasColumnName("PhysicalSensation");
            builder.Property(x => x.FoodRestrictions).HasColumnName("FoodRestrictions");
            builder.Property(x => x.Weight).HasColumnName("Weight");
            builder.Property(x => x.ClientId).HasColumnName("ClientId");

            builder.HasOne(a => a.Client).WithMany(c => c.Appointments).HasForeignKey(a => a.ClientId);

        }
    }
}
