using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resume_Filter.Application.DTO.HR;
using Resume_Filter.Application.DTO.Property;
using Resume_Filter.Application.DTO.Vacancy;
using Resume_Filter.Application.UseCases.Commands.HR;
using Resume_Filter.Application.UseCases.Commands.Property;
using Resume_Filter.Application.UseCases.Commands.Vacancy;
using Resume_Filter.Domain.Entities.HR;
using Resume_Filter.Domain.Entities.Property;
using Resume_Filter.Domain.Entities.Vacancy;

namespace Resume_Filter.Application.Mappers;

public class MappingConfiguration:Profile
{
    public MappingConfiguration()
    {
        CreateMap<CreateRecruiter, CreateRecruiterDTO>().ReverseMap();
        CreateMap<UpdateRecruiter, UpdateRecruiterDTO>().ReverseMap();

        CreateMap<CreateProperty, CreatePropertyDTO>().ReverseMap();
        CreateMap<UpdateProperty, UpdatePropertyDTO>().ReverseMap();

        CreateMap<CreateVacancy, CreateVacancyDTO>().ReverseMap();
        CreateMap<UpdateVacancy, UpdateVacancyDTO>().ReverseMap();

        //---------------

        CreateMap<CreateVacancy, Vacancies>().ReverseMap();
        CreateMap<CreateRecruiter, Recruiter>().ReverseMap();
        CreateMap<CreateProperty, Properties>().ReverseMap();
    }
}

