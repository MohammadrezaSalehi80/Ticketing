using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    internal class TicketsConfigurations : IEntityTypeConfiguration<Tickets>
    {
        public void Configure(EntityTypeBuilder<Tickets> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasColumnType("nvarchar(150)").IsRequired();

            builder.Property(x => x.Description).HasColumnType("nvarchar(500)").IsRequired(true);

            builder.Property(x=>x.CreatedAt).IsRequired();

            builder.Property(x=>x.Status).HasConversion<string>().IsRequired();

            builder.Property(x=>x.Priority).HasConversion<string>().IsRequired();

            builder.Property(x=>x.AssignedToUserId).IsRequired(false);



            builder.HasOne(t=>t.CreatedByUser)
                .WithMany()
                .HasForeignKey(t => t.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t=>t.AssignedToUser)
                .WithMany()
                .HasForeignKey(t => t.AssignedToUserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
