using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spd3.Data.Dicts;
using Spd3.Models.Entities;

namespace Spd.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
	    private readonly IDataSeeder<Kved> _kvedSeeder;

		private readonly IDataSeeder<Bank> _mfoSeeder;

		private readonly IDataSeeder<Region> _regionSeeder;

		public ApplicationDbContext(DbContextOptions options, IDataSeeder<Kved> kvedSeeder, 
			IDataSeeder<Bank> mfoSeeder, IDataSeeder<Region> regionSeeder)
		   : base(options)
		{
			_kvedSeeder = kvedSeeder;
			_mfoSeeder = mfoSeeder;
			_regionSeeder = regionSeeder;
		}

		public DbSet<TaxPerson> TaxPersons { get; set; }

		public DbSet<Kved> Kveds { get; set; }

		public DbSet<Region> Regions { get; set; }

		public DbSet<TaxInspection> TaxInspections { get; set; }

		public DbSet<TaxPersonKved> TaxPersonKveds { get; set; }

		public DbSet<Bank> Banks { get; set; }

		public DbSet<TaxAccount> TaxAccounts { get; set; }

		public DbSet<TaxAccountType> TaxAccountTypes { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//application user table
			base.OnModelCreating(builder);
			builder.Entity<AppUser>()
				.Property(b => b.RealName).HasMaxLength(255);

			//kved
			builder.Entity<Kved>()				
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

			//regions
			builder.Entity<Region>()
				.Property(b => b.Name).HasMaxLength(64);

			builder.Entity<Region>()
				.HasMany(e => e.TaxInspections)
				.WithOne(e => e.Region)
				.HasForeignKey(e => e.RegionId);

			builder.Entity<Region>()
				.HasData(_regionSeeder.GetEntities);

			//tax regions
			builder.Entity<TaxInspection>()
				.HasMany(e => e.TaxPersons)
				.WithOne(e => e.TaxInspection)
				.HasForeignKey(e => e.TaxInspectionId);

			builder.Entity<TaxPersonKved>()
				.Property(b => b.KvedCode).HasMaxLength(10);

			//tax person
			builder.Entity<TaxPerson>()
				.Property(b => b.FullName).HasMaxLength(64);

			builder.Entity<TaxPerson>()
				.Property(b => b.TaxCode).HasMaxLength(16);

			builder.Entity<TaxPerson>()
				.Property(b => b.ZipCode).HasMaxLength(5);

			builder.Entity<TaxPerson>()
				.Property(b => b.City).HasMaxLength(32);

			builder.Entity<TaxPerson>()
				.Property(b => b.Street).HasMaxLength(64);

			builder.Entity<TaxPerson>()
				.HasMany(e => e.TaxPersonKveds)
				.WithOne(e => e.TaxPerson)
				.HasForeignKey(e => e.TaxPersonId);

			//bank
			builder.Entity<Bank>()
				.HasKey(b => b.Mfo);

			builder.Entity<Bank>()
				.Property(b => b.Mfo).HasMaxLength(6);

			builder.Entity<Bank>()
				.Property(b => b.Name).HasMaxLength(256);
			
			builder.Entity<Bank>()
				.HasData(_mfoSeeder.GetEntities);

			//AccountType
			builder.Entity<TaxAccountType>()
				.Property(b => b.Name).HasMaxLength(128);

			builder.Entity<TaxAccountType>()
				.HasMany(e => e.TaxAccounts)
				.WithOne(e => e.TaxAccountType)
				.HasForeignKey(e => e.AccountTypeId);

			builder.Entity<TaxAccountType>()
				.HasData(new TaxAccountType[]
				{
					new TaxAccountType()
					{
						Id = 1,
						Name = "ФОП, Єдиний податок"

					},
					new TaxAccountType()
					{
						Id = 2,
						Name = "ФОП, Єдиний соціальній внесок"
					}
				});
			
			//TacAccount
			builder.Entity<TaxAccount>()
				.Property(b => b.Mfo).HasMaxLength(6);

			builder.Entity<TaxAccount>()
				.Property(b => b.Edrpou).HasMaxLength(10);

			builder.Entity<TaxAccount>()
				.Property(b => b.Edrpou).HasMaxLength(20);

			builder.Entity<TaxAccount>()
				.Property(b => b.Name).HasMaxLength(256);

			builder.Entity<TaxAccount>()
				.Property(b => b.BankName).HasMaxLength(256);
		}
	}
}
