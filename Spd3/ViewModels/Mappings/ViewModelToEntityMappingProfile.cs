using AutoMapper;
using Spd.Models.Entities;

namespace Spd.ViewModels.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
	{
		public ViewModelToEntityMappingProfile()
		{
			CreateMap<RegistrationViewModel, AppUser>()
				.ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email))
				.ForMember(au => au.RealName, map => map.MapFrom(vm => vm.RealName));
		}
	}
}
