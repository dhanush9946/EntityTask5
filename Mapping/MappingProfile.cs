using AutoMapper;
using Task5.DTOs;
using Task5.Models;

namespace Task5.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeReadDto>()
                .ForMember(dest => dest.DepartmentName,
                opt => opt.MapFrom(src => src.Department.DepartmentName));

            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<Department, DepartmentDto>();
        }
    }
}
