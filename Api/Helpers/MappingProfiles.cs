using Api.DTOs;
using AutoMapper;
using Core.Models;

namespace Api.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentToCreateDTO, Department>();
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(m => m.Department, d => d.MapFrom(s => s.Department));

            CreateMap<EmployeeToAddDTO, Employee>();
        }
        
    }
}
