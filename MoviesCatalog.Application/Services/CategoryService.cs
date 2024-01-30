using AutoMapper;
using MoviesCatalog.Application.DTOs;
using MoviesCatalog.Application.Interfaces;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;

namespace MoviesCatalog.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository ??
                              throw new ArgumentNullException(nameof(categoryRepository));;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetAsync()
    {
        var categories = await _categoryRepository.GetAsync();

        return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task<CategoryDTO> GetAsync(int? id)
    {
        var category = await _categoryRepository.GetAsync(id);
        
        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task CreateAsync(CategoryDTO categoryDTO)
    {
        var category = _mapper.Map<Category>(categoryDTO);

        await _categoryRepository.CreateAsync(category);
    }

    public async Task UpdateAsync(CategoryDTO categoryDTO)
    {
        var category = _mapper.Map<Category>(categoryDTO);

        await _categoryRepository.UpdateAsync(category);
    }

    public async Task RemoveAsync(int? id)
    {
        var category = _categoryRepository.GetAsync(id).Result;

        await _categoryRepository.RemoveAsync(category);
    }
}