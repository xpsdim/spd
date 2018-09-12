using AutoMapper;
using Spd.Data.Dicts.DictSourceModels;
using Spd.Models.Entities;

namespace Spd.Data.Dicts.Mappings
{
	public class KvedModelToKvedMappingProfile : Profile
	{
		public KvedModelToKvedMappingProfile()
		{
			CreateMap<KvedModel, Kved>()
				.ForMember(au => au.ChildrenKvedList, opt => opt.Ignore())
				.ForMember(au => au.ParentKved, opt => opt.Ignore())
				.ForMember(au => au.Code, map => map.MapFrom(model => model.Code.Trim()))
				.ForMember(au => au.ParentCode, map => map.MapFrom(model => model.ParentCode.Trim()));
		}
	}
}
