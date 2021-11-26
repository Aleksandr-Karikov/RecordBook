using Microsoft.EntityFrameworkCore;
using RecordBook.DataBase.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordBook.DataBase
{
    public class RecordBkContext : DbContext
    {
        public RecordBkContext() { }
        public RecordBkContext(DbContextOptions<RecordBkContext> options) : base(options)
        {
            Database.EnsureCreatedAsync();
        }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<RecordBk>Recordbooks{get;set;}
        protected override void OnModelCreating(ModelBuilder modelBilder)
        {
            base.OnModelCreating(modelBilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local)\\sqlexpress;Database=RecordBook;Trusted_Connection=True;");
        }
    }
}
