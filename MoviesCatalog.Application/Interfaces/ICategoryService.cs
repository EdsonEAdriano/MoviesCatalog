using MoviesCatalog.Application.DTOs;

namespace MoviesCatalog.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAsync();
    Task<CategoryDTO> GetAsync(int? id);

    Task CreateAsync(CategoryDTO categoryDTO);
    Task UpdateAsync(CategoryDTO categoryDTO);
    Task RemoveAsync(int? id);
}