using AutoMapper;
using UniSoft.Application.Interfaces;

namespace UniSoft.Application.Services
{
    public class BaseService : IBaseService
    {
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
