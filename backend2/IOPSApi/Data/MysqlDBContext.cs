using System;
using Microsoft.EntityFrameworkCore;
using IOPSApi.Models;
namespace IOPSApi.Data
{
    public class MysqlDBContext : DbContext
    {
        public DbSet<User> Users { set; get; }
		public DbSet<Admin> Admins { set; get; }
        public DbSet<Context> Contexts { set; get; }
        public DbSet<Inscription> Inscriptions { set; get; }
        public DbSet<Country> Countries { set; get; }
        public DbSet<Continent> Continent { set; get; }
		public DbSet<News> News { set; get; }
        public DbSet<Messages> Messages { set; get; }
        public DbSet<Event> Events { set; get; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql(@"Server=localhost;database=IOPS;uid=root;pwd=;"); 
		}

	}
}
