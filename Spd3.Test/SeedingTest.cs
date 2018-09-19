using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spd3.Data.Dicts;
using AutoMapper;
using Spd.Data.Dicts.Mappings;
using System.Linq;
using Spd.Helpers;

namespace Spd.Test
{
	[TestClass]
	public class SeedingTest
	{
		[TestInitialize]
		public void Init()
		{
			
		}

		[TestMethod]
		public void TestKvedSeeder()
		{
			var mapper = new Mapper(
				new MapperConfiguration(
					configure => { configure.AddProfile<SeedingModelsMappingProfile>(); }
				)
			);
			var kvedSeeder = new KvedSeeder(mapper, webPathMapper: new TestWebRootPathMapper());
			var kveds = kvedSeeder.GetEntities;
			Assert.IsTrue(kveds.Any());
		}

		[TestMethod]
		public void TestMfoSeeder()
		{
			var mapper = new Mapper(
				new MapperConfiguration(
					configure => { configure.AddProfile<SeedingModelsMappingProfile>(); }
				)
			);
			var mfoSeeder = new MfoSeeder(mapper, webPathMapper: new TestWebRootPathMapper());
			var banks = mfoSeeder.GetEntities;
			Assert.IsTrue(banks.Any());
		}

		[TestMethod]
		public void TestRegionSeeder()
		{
			var mapper = new Mapper(
				new MapperConfiguration(
					configure => { configure.AddProfile<SeedingModelsMappingProfile>(); }
				)
			);
			var regionSeeder = new RegionSeeder(mapper, webPathMapper: new TestWebRootPathMapper());
			var regions = regionSeeder.GetEntities;
			Assert.IsTrue(regions.Any());
		}
	}
}
