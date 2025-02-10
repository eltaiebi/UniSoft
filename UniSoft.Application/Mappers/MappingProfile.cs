using AutoMapper;
using UniSoft.Application.DTOs;
using UniSoft.Domain.Entities;


namespace UniSoft.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // DatabaseTable
            CreateMap<DatabaseTable, DatabaseTableDto>().ReverseMap();
            CreateMap<DatabaseColumn, DatabaseColumnDto>().ReverseMap();

            // Application
            CreateMap<Domain.Entities.Application, ApplicationDto>().ReverseMap();
            CreateMap<MenuElement, MenuElementDto>().ReverseMap();

            // Page
            CreateMap<Page, PageDto>().ReverseMap();

            // Component
            CreateMap<Component, ComponentDto>().ReverseMap();

            // FormComponentField
            CreateMap<FormComponentField, FormComponentFieldDto>()
                .ReverseMap();

        }
    }
}