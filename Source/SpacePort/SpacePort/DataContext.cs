using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Receipt> Receipt { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(a => a.Receipt)
                .WithOne(b => b.Ticket);
            //.HasForeignKey<Receipt>(x => x.TicketRef);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("Appsettings.Json")
                .Build();

            var defaultConnection = configuration.GetConnectionString("DefaultConnection");
            optionBuilder.UseSqlServer(defaultConnection);



            //    optionBuilder.UseSqlServer(@"SERVER = den1.mssql7.gear.host; DATABASE = spaceportdb; UID = spaceportdb; PWD = Gk03R!351K-W");

            //    optionBuilder.UseSqlServer(@"data source =.\SQLEXPRESS; initial catalog = SpacePort; integrated security = SSPI");
            //    base.OnConfiguring(optionBuilder);

            //    optionBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["coreData"].ToString());
        }
    }
}
