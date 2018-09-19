using System.Collections.Generic;
using System.IO;
using System.Linq;
using Spd3.Models.Entities;
using IMapper = AutoMapper.IMapper;
using Spd3.Data.Dicts.DictSourceModels;
using Spd.Helpers;

namespace Spd3.Data.Dicts
{
	public class KvedSeeder : IDataSeeder<Kved>
	{		
		private readonly IMapper _mapper;
		private readonly IWebRootPathMapper _webPathMapper;

		public KvedSeeder(IMapper mapper, IWebRootPathMapper webPathMapper)
		{			
			_mapper = mapper;
			_webPathMapper = webPathMapper;
		}

		public Kved[] GetEntities => ReadFromCsv();

		private Kved[] ReadFromCsv()
		{
			var fromFileKveds = new List<KvedModel>();
			
			using (var reader = new StreamReader(_webPathMapper.MapPath(@"Data\Dicts\kved2010.csv")))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					if (!string.IsNullOrEmpty(line))
					{
						var values = line.Split(':');
						fromFileKveds.Add(new KvedModel()
						{
							Code = values[0].Trim(),
							Name = values[1].Trim(),
							ParentCode = values[2].Trim()
						});
					}
				}
			}

			if (fromFileKveds.Any())
			{
				var result = new List<Kved>();
				
				foreach (var rootKved in fromFileKveds.Where(kved => string.IsNullOrEmpty(kved.ParentCode)).Select(kved => _mapper.Map<Kved>(kved)))
				{
					rootKved.ParentCode = null;
					result.Add(rootKved);

					result.AddRange(ProcessChildItems(rootKved, fromFileKveds));
				}
				
				return result.ToArray();
			}

			return null;
		}

				
		private List<Kved> ProcessChildItems(Kved parentKved, List<KvedModel> rawKvedList)
		{
			var result = new List<Kved>();
			var children =
				rawKvedList.Where(kved => kved.ParentCode == parentKved.Code)
				.Select(kved => _mapper.Map<Kved>(kved));
			result.AddRange(children);
			foreach(var child in children)
			{
				child.ParentCode = parentKved.Code;
				result.AddRange(ProcessChildItems(child, rawKvedList));
			}
			return result;
		}		
		
	}
}
