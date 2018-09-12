using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spd.Models.Entities;
using Spd.Data.Dicts;

namespace Spd.Data
{
    public class ApplicationDbContext : IdentityDbContext<TaxAccountant>
    {
	    private readonly IDataSeeder<Kved> _kvedSeeder;
		public ApplicationDbContext(DbContextOptions options, IDataSeeder<Kved> kvedSeeder)
		   : base(options)
		{
			_kvedSeeder = kvedSeeder;
		}

		public DbSet<TaxPerson> TaxPersons { get; set; }
		public DbSet<Kved> Kveds { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//application user table
			base.OnModelCreating(builder);
			builder.Entity<TaxAccountant>()
				.Property(b => b.RealName).HasMaxLength(255);

			//kved
			builder.Entity<Kved>()
				.ToTable("dictKved")
				.HasKey(b => b.Code);

			builder.Entity<Kved>()				
				.HasMany(e => e.ChildrenKvedList)
				.WithOne(e => e.ParentKved)				
				.HasForeignKey(e => e.ParentCode);

			builder.Entity<Kved>()
				.Property(b => b.Code).HasMaxLength(10);

			builder.Entity<Kved>()
				.Property(b => b.ParentCode).HasMaxLength(10);

			builder.Entity<Kved>()
				.HasData(_kvedSeeder.GetEntities);
		}
	}
}
