using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniSoft.Application.DTOs;
using UniSoft.Application.Interfaces;
using UniSoft.Application.Services;
using UniSoft.Domain.Entities;
using UniSoft.Domain.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using static UniSoft.Application.Interfaces.IService;

namespace UniSoft.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMenuElementRepository _menuElementRepository;
        private readonly IPageRepository _pageRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly IPageComponentRepository _pageComponentRepository;
        private readonly IFormComponentFieldRepository _formComponentFieldRepository;
        private readonly IDatabaseTableRepository _databaseTableRepository;
        private readonly IDatabaseColumnRepository _databaseColumnRepository;


        private readonly IMapper _mapper;

        public ApplicationService(
            IApplicationRepository applicationRepository,
            IMenuElementRepository menuElementRepository,
            IPageRepository pageRepository,
            IComponentRepository componentRepository,
            IPageComponentRepository pageComponentRepository,
            IFormComponentFieldRepository formComponentFieldRepository,
            IDatabaseTableRepository databaseTableRepository,
            IDatabaseColumnRepository databaseColumnRepository,
            IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _menuElementRepository = menuElementRepository;
            _pageRepository = pageRepository;
            _componentRepository = componentRepository;
            _pageComponentRepository = pageComponentRepository;
            _formComponentFieldRepository = formComponentFieldRepository;
            _databaseColumnRepository = databaseColumnRepository;
            _databaseTableRepository = databaseTableRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationDto> GetApplicationDetailsAsync(int applicationId)
        {
            var applications = await _applicationRepository.GetAllAsync();
            var databaseTables = await _databaseTableRepository.GetAllAsync();
            var databaseColumns = await _databaseColumnRepository.GetAllAsync();
            var menuElements = await _menuElementRepository.GetAllAsync();
            var pages = await _pageRepository.GetAllAsync();
            var components = await _componentRepository.GetAllAsync();
            var pageComponents = await _pageComponentRepository.GetAllAsync();
            var formComponentFields = await _formComponentFieldRepository.GetAllAsync();

            foreach (var application in applications)
            {
                application.MenuElements = menuElements.ToList();
                foreach (var menuElement in application.MenuElements)
                {
                    menuElement.Page = pages.First(x=>x.Id == x.Id);
                    foreach (var componentPage in pageComponents)
                    {
                        if (componentPage.PageId != menuElement.PageId)
                            continue;

                        var component = components.First(x => x.Id == componentPage.ComponentId);
                        if(component.Type == Domain.Entities.ComponentType.Form) 
                            component.Fields = formComponentFields.Where(x=>x.Id == component.Id).ToList();

                        menuElement.Page.Components.Add(component);
                    }
                }
            }

            return _mapper.Map<ApplicationDto>(applications.First()); 
        }

    }




}


