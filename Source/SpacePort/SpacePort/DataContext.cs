using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort.Models
{
    class DataContext: DbContext
    {
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"SERVER = den1.mssql7.gear.host; DATABASE = spaceportdb; UID = spaceportdb; PWD = Gk03R!351K-W");

            //optionBuilder.UseSqlServer(@"data source =.\SQLEXPRESS; initial catalog = SpacePort; integrated security = SSPI");
            //base.OnConfiguring(optionBuilder);
            //optionBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["coreData"].ToString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(a => a.ReceiptId)
                .WithOne(b => b.TicketId)
                .HasForeignKey<Receipt>(b => b.TicketRef);
        }
    }
}
