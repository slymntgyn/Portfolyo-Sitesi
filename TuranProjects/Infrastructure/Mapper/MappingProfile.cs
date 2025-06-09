using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace TuranProjects_Portfolio.Infrastructure.Mapper {
	public class MappingProfile : Profile {
		public MappingProfile() {
			CreateMap<ENTITIES.Dtos.UserDtoForCreation, IdentityUser>();
			CreateMap<ENTITIES.Dtos.UserDtoForUpdate, IdentityUser>().ReverseMap();
		}

	}
}
