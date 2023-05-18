using ASPFinance.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPFinance.Model
{
	public class FinanceContext : DbContext
	{
		private readonly ILoggerFactory _loggerFactory;

		public FinanceContext()
		{
		}

		public FinanceContext(DbContextOptions<FinanceContext> options)
			: base(options)
		{
		}
		
		public FinanceContext(DbContextOptions<FinanceContext> options, ILoggerFactory loggerFactory)
			: base(options)
		{
			_loggerFactory = loggerFactory;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
			.UseLoggerFactory(_loggerFactory);

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Supplier>().HasData(new Supplier[]
			{
				new Supplier()
				{
					Id = 1,
					Name = "Forncedor 1",
				},
				new Supplier()
				{
					Id = 2,
					Name = "Forncedor 2",
				},
				new Supplier()
				{
					Id = 3,
					Name = "Forncedor 2",
				}
			});


			modelBuilder.Entity<Customer>().HasData(new Customer[]
			{
				new Customer()
				{
					Id = 1,
					Name = "Cliente 1",
				},
				new Customer()
				{
					Id = 2,
					Name = "Cliente 2",
				}
			});

			modelBuilder.Entity<Debit>().HasData(new Debit[]
			{
				new Debit()
				{
					Id = 1,
					Title = "Energia",
					Descripton = "Campanhia de Distribuição de Energia",
					DebtDay = DateTime.Now.AddHours(-1).AddMinutes(-30),
					Value = 500.99m,
					SupplierId = 1
				},
				new Debit()
				{
					Id = 2,
					Title = "Água e esgoto",
					Descripton = "Campanhia de Tratamento de Agua e esgoto",
					DebtDay = DateTime.Now.AddHours(-1).AddMinutes(-15),
					Value = 400.99m,
					SupplierId = 2
				},
				new Debit()
				{
					Id = 3,
					Title = "Internet",
					Descripton = "Campanhia de Comunicações",
					DebtDay = DateTime.Now.AddHours(-1).AddMinutes(-10),
					Value = 300.99m,
					SupplierId = 3
				},
				new Debit()
				{
					Id = 4,
					Title = "Telefone",
					Descripton = "Campanhia de Comunicações",
					DebtDay = DateTime.Now.AddHours(-1).AddMinutes(-05),
					Value = 350.99m,
					SupplierId = 3
				}
			});

			modelBuilder.Entity<Credit>().HasData(new Credit[]
			{
				new Credit()
				{
					Id = 1,
					Title = "Samsung S1",
					Descripton = "Samsung modelo S1",
					CreditDay = DateTime.Now.AddHours(-1).AddMinutes(-25),
					Value = 5000.99m,
					CustomerId = 1
				},
				new Credit()
				{
					Id = 2,
					Title = "Motolora M1",
					Descripton = "Motolora modelo M1",
					CreditDay = DateTime.Now.AddHours(-1).AddMinutes(-20),
					Value = 4000.99m,
					CustomerId = 1
				},
				new Credit()
				{
					Id = 3,
					Title = "LG LG1",
					Descripton = "LG modelo LG1",
					CreditDay = DateTime.Now.AddHours(-1).AddMinutes(-15),
					Value = 3000.99m,
					CustomerId = 2
				},
				new Credit()
				{
					Id = 4,
					Title = "Motolora M2",
					Descripton = "Motolora modelo M2",
					CreditDay = DateTime.Now.AddHours(-1).AddMinutes(-15),
					Value = 3509.99m,
					CustomerId = 2
				}
			});
		}

		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<Debit> Debits { get; set; }
		public DbSet<Credit> Credits { get; set; }
		public DbSet<Customer> Customers { get; set; }
	}
}
