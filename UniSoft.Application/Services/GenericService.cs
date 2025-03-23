using AutoMapper;
using UniSoft.Application.Interfaces;
using UniSoft.Domain.Interfaces;

namespace UniSoft.Application.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
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
            var entity = _mapper.Map<TEntity>(dto);
            return await _repository.AddAsync(entity);
        }

        public async Task<int> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}