using AutoMapper;
using UniSoft.Application.DTOs;
using UniSoft.Domain.Entities;


namespace UniSoft.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DatabaseTable, DatabaseTableDto>().ReverseMap();
            CreateMap<DatabaseColumn, DatabaseColumnDto>().ReverseMap();
            CreateMap<Domain.Entities.Application, ApplicationDto>().ReverseMap();
            CreateMap<MenuElement, MenuElementDto>().ReverseMap();
            CreateMap<Page, PageDto>().ReverseMap();
            CreateMap<Component, ComponentDto>().ReverseMap();
            CreateMap<FormComponentField, FormComponentFieldDto>().ReverseMap();
            CreateMap<DynamicData, DynamicDataDto>().ReverseMap();
        }
    }
}