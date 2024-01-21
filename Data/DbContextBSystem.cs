using System;
using System.Collections.Generic;
using System.Text;
using BankingProyect.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace BankingProyect.Data
{
	public class DbContextBSystem: DbContext
	{
		public DbContextBSystem()
		{

		}
		public DbContextBSystem(DbContextOptions<DbContextBSystem> options): base(options) { }
		public DbSet<Users> Users { get; set; }
		public DbSet<Accounts> Acounts { get; set; }
		public DbSet<Currencys> Currencys { get; set; }
		public DbSet<Commisions> Commisions { get; set; }
		public DbSet<Operations> Operations { get; set; }
		public DbSet<Journal> Journal { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
			.UseSqlServer("Server=DESKTOP-VTO0H7T\\SQLDEVLOPER;Database=BankingDB;Trusted_Connection=True;");
	}
}
