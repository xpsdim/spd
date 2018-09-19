using AutoMapper;
using NDbfReader;
using Spd.Helpers;
using Spd3.Data.Dicts.DictSourceModels;
using Spd3.Models.Entities;
using System.Collections.Generic;
using System.Text;

namespace Spd3.Data.Dicts
{
	public class MfoSeeder : IDataSeeder<Bank>
	{
		private readonly IMapper _mapper;
		private readonly IWebRootPathMapper _webPathMapper;

		public MfoSeeder(IMapper mapper, IWebRootPathMapper webPathMapper)
		{
			_mapper = mapper;
			_webPathMapper = webPathMapper;
		}

		public Bank[] GetEntities => GetMfoList();

		private Bank[] GetMfoList()
		{
			var result = new List<Bank>();

			using (var table = Table.Open(_webPathMapper.MapPath(@"Data\Dicts\RCUKRU.DBF")))
			{
				var enc1251 = CodePagesEncodingProvider.Instance.GetEncoding(866);
				var reader = table.OpenReader(enc1251);				
				while (reader.Read())
				{
					var bank = new BankModel()
					{
						Mfo = reader.GetDecimal("MFO").ToString(),
						Name = reader.GetString("NB")
							.Replace("ї", "є")
							.Replace("Ї", "Є")
							.Replace("ў", "і")
							.Replace("Ў", "І")
							.Replace("∙", "ї")
							.Replace("°", "Ї")
					};
					result.Add(_mapper.Map<Bank>(bank));
				}				
			}

			return result.ToArray();
		}
	}
}
