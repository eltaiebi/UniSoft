using AutoMapper;
using UniSoft.Domain.Interfaces;
using static UniSoft.Application.Interfaces.IService;

namespace UniSoft.Application.Services
{
    public class Service<T, TDto> : IService<T, TDto> where T : class where TDto : class
    {
        private readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;

        public Service(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<int> AddAsync(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            return await _repository.AddAsync(entity);
        }

        public async Task<int> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }



}
