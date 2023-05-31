using AutoMapper;
using QueueManager.Application.DTOs.AdminDTO.PermissionDTO;
using QueueManager.Application.DTOs.AdminDTO.RoleDTO;
using QueueManager.Application.DTOs.AdminDTO.UserDTO;
using QueueManager.Application.DTOs.Common.CategoryDTO;
using QueueManager.Application.DTOs.Common.ClinicDTO;
using QueueManager.Application.DTOs.Common.DoctorDTO;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.Application.Mappings
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<PermissionOutcomingDTO, Permission>().ReverseMap();
            CreateMap<PermissionCreateDTO, Permission>().ReverseMap();
            CreateMap<PermissionUpdateDTO, Permission>().ReverseMap();


            CreateMap<RoleCreateDTO, Role>()
                .ForMember(dest => dest.Permissions, src => src.MapFrom(r => r.PermissionIds.Select(id => new Permission() { Id = id }).ToList()));
            CreateMap<Role, RoleCreateDTO>()
                .ForMember(dest => dest.PermissionIds, src => src.MapFrom(r => r.Permissions.Select(p => p.Id).ToList()));
            CreateMap<RoleOutcomingDTO, Role>()
               .ForMember(dest => dest.Permissions, src => src.MapFrom(r => r.PermissionIds.Select(id => new Permission() { Id = id }).ToList()));
            CreateMap<Role, RoleOutcomingDTO>()
                .ForMember(dest => dest.PermissionIds, src => src.MapFrom(r => r.Permissions.Select(p => p.Id).ToList()));
            CreateMap<RoleUpdateDTO, Role>()
                .ForMember(dest => dest.Permissions, src => src.MapFrom(r => r.PermissionIds.Select(id => new Permission() { Id = id }).ToList()));
            CreateMap<Role, RoleUpdateDTO>()
                .ForMember(dest => dest.PermissionIds, src => src.MapFrom(r => r.Permissions.Select(p => p.Id).ToList()));



            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleIds.Select(id => new Role() { Id = id })));
            CreateMap<User, UserCreateDTO>()
                .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.Roles.Select(r => r.Id)));
            CreateMap<UserOutcomingDTO, User>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleIds.Select(id => new Role() { Id = id })));
            CreateMap<User, UserOutcomingDTO>()
                .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.Roles.Select(r => r.Id)));
            CreateMap<UserUpdateDTO, User>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleIds.Select(id => new Role() { Id = id })));
            CreateMap<User, UserUpdateDTO>()
                .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.Roles.Select(r => r.Id)));

            CreateMap<CategoryCreateDTO, Category>().ReverseMap();
            CreateMap<CategoryOutcomingDTO, Category>().ReverseMap();

            CreateMap<ClinicCreateDTO, Clinic>().ReverseMap();
            CreateMap<ClinicOutcomingDTO, Clinic>().ReverseMap();

            CreateMap<DoctorCreateDTO, Doctor>().ReverseMap();
            CreateMap<DoctorOutcomingDTO, DoctorCreateDTO>().ReverseMap();
        }
    }
}
