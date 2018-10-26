using AutoMapper;
using Spd.Helpers;
using Spd3.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Spd3.Data.Dicts
{
	public class RegionSeeder : IDataSeeder<Region>
	{
		private readonly IMapper _mapper;
		private readonly IWebRootPathMapper _webPathMapper;

		public RegionSeeder(IMapper mapper, IWebRootPathMapper webPathMapper)
		{
			_mapper = mapper;
			_webPathMapper = webPathMapper;
		}

		public Region[] GetEntities => GetRegionList();

		private Region[] GetRegionList()
		{
			var result = new List<Region>();

			using (var reader = new StreamReader(_webPathMapper.MapPath(@"Data\Dicts\regions.csv")))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					if (!string.IsNullOrEmpty(line))
					{
						var values = line.Split(':');
						result.Add(new Region() {
							Id = Convert.ToInt16(values[0].Trim()),
							Name = values[1].Trim(),
							Order = Convert.ToInt16(values[2].Trim()),
						});
					}
				}
			}

			return result.Select(r => _mapper.Map<Region>(r)).ToArray();
		}
	}
}
