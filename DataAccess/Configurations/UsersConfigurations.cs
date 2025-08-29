using Domain.Models.Entities;
using Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    internal class UsersConfigurations : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);

            builder.Property(x=>x.Password).IsRequired();

            builder.Property(x=>x.FullName).HasColumnType("nvarchar(60)").IsRequired();

            builder.Property(x=>x.Role).HasConversion<string>().IsRequired();

            builder.HasData
                (
                    new Users()
                    {
                        Id = Guid.Parse("95ED9D38-3239-4C3A-A319-34A5F42C49E3"),
                        Email = "Admin@Test.com",
                        FullName = "Admin",
                        Role = Role.Admin,

                        //Admin@123 for test
                        Password = "$2a$11$ASaqrgVW3lBlqU5cusgoIOzcQhsxRcqv/c7EQInMd.pkQNvTyjpEC"
                    },
                    

                    new Users()
                    {
                        Id = Guid.Parse("{A280ED6E-89AA-42B4-B80F-80A55C7916AB}"),
                        Email = "Employee@Test.com",
                        FullName = "Employee",
                        Role = Role.Employee,

                        //Employee@123 for test
                        Password = "$2a$11$JkQLUOIddfe6kncslvVxZ..8mYvABxqRlIQsZC/rb1aJA7Jv0ExKa"
                    }

                );

        }
    }
}
