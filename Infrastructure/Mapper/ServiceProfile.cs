using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Mapper;

public class ServiceProfile:Profile
{
    public ServiceProfile()
    {
        CreateMap<AddStudentDto, Student>()
            .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => src.Image.FileName)).ReverseMap();
        CreateMap<Student, GetStudentDto>().ReverseMap();
        CreateMap<AddStudentDto, GetStudentDto>().ReverseMap();
    }
}
