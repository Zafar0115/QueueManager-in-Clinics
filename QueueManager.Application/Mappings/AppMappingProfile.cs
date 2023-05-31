using AutoMapper;
using QueueManager.Application.DTOs.AdminDTO.PermissionDTO;
using QueueManager.Application.DTOs.AdminDTO.RoleDTO;
using QueueManager.Application.DTOs.AdminDTO.UserDTO;
using QueueManager.Application.DTOs.Common.CategoryDTO;
using QueueManager.Application.DTOs.Common.ClinicDTO;
using QueueManager.Application.DTOs.Common.DoctorDTO;
using QueueManager.Application.DTOs.Common.DoctorRatingDTO;
using QueueManager.Application.DTOs.Common.HistoryDTO;
using QueueManager.Application.DTOs.Common.PatientDTO;
using QueueManager.Application.DTOs.Common.WaitListDTO;
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

            CreateMap<RoleCreateDTO, Role>()
                .ForMember(dest => dest.Permissions, src => src.MapFrom(r => r.PermissionIds.Select(id => new Permission() { Id = id }).ToList()));
            CreateMap<RoleOutcomingDTO, Role>()
               .ForMember(dest => dest.Permissions, src => src.MapFrom(r => r.PermissionIds.Select(id => new Permission() { Id = id }).ToList()));
            CreateMap<Role, RoleOutcomingDTO>()
                .ForMember(dest => dest.PermissionIds, src => src.MapFrom(r => r.Permissions.Select(p => p.Id).ToList()));

            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleIds.Select(id => new Role() { Id = id })));
            CreateMap<UserOutcomingDTO, User>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleIds.Select(id => new Role() { Id = id })));
            CreateMap<User, UserOutcomingDTO>()
                .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.Roles.Select(r => r.Id)));

            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryOutcomingDTO, Category>().ReverseMap();

            CreateMap<ClinicCreateDTO, Clinic>();
            CreateMap<ClinicOutcomingDTO, Clinic>().ReverseMap();

            CreateMap<DoctorCreateDTO, Doctor>()
                .ForMember(dest => dest.Clinics, opt => opt.MapFrom(src => src.ClinicIds.Select(id => new Clinic() { ClinicId = id })));
            CreateMap<DoctorOutcomingDTO, Doctor>()
                .ForMember(dest => dest.Clinics, opt => opt.MapFrom(src => src.ClinicIds.Select(id => new Clinic() { ClinicId = id })));
            CreateMap<Doctor, DoctorOutcomingDTO>()
                .ForMember(dest => dest.ClinicIds, opt => opt.MapFrom(src => src.Clinics.Select(id => id)));

            CreateMap<DoctorRatingCreateDTO, DoctorRating>();
            CreateMap<DoctorRatingOutcomingDTO, DoctorRating>().ReverseMap();

            CreateMap<PatientCreateDTO, Patient>();
            CreateMap<PatientOutcomingDTO, Patient>().ReverseMap();

            CreateMap<WaitListCreateDTO, WaitList>();
            CreateMap<WaitListOutcomingDTO, WaitList>().ReverseMap();

            CreateMap<HistoryCreateDTO, History>();
            CreateMap<HistoryOutcomingDTO, History>().ReverseMap();
        }
    }
}
