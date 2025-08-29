using DataAccess.Configurations;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> dbContext):
            base(dbContext)
        { 
        }

        DbSet<Users> Users { get; set; }
        DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfigurations());
            modelBuilder.ApplyConfiguration(new TicketsConfigurations());
            
            


            base.OnModelCreating(modelBuilder);
        }

    }
}
