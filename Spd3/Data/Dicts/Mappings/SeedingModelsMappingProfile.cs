using AutoMapper;
using Spd3.Data.Dicts.DictSourceModels;
using Spd3.Models.Entities;

namespace Spd.Data.Dicts.Mappings
{
	public class SeedingModelsMappingProfile : Profile
	{
		public SeedingModelsMappingProfile()
		{
			CreateMap<KvedModel, Kved>()
				.ForMember(au => au.ChildrenKvedList, opt => opt.Ignore())
				.ForMember(au => au.ParentKved, opt => opt.Ignore())
				.ForMember(au => au.Code, map => map.MapFrom(model => model.Code.Trim()))
				.ForMember(au => au.ParentCode, map => map.MapFrom(model => model.ParentCode.Trim()));

			CreateMap<BankModel, Bank>();

			CreateMap<RegionModel, Region>();
		}
	}
}
