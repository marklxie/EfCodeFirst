using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirst {
	public class AppDbContext: DbContext {

		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<Orderline> Orderlines { get; set; }
		public AppDbContext(DbContextOptions options) :base(options) { }
		public AppDbContext() : base() { }

		//Class file startup. Won't need statement if have startup class.
		protected override void OnConfiguring(DbContextOptionsBuilder options) {
			if(!options.IsConfigured) {
				options.UseSqlServer("server=localhost\\sqlexpress;database=CustOrdDb;trusted_connection=true;");
			}
		}

		protected override void OnModelCreating(ModelBuilder builder) {
			builder.Entity<Customer>(e => { 
				e.HasIndex(x => x.Code).IsUnique(true);
			});
		}

	}
}
