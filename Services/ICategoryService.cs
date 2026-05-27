using FinanceAPI.DTOs;

namespace FinanceAPI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetAllAsync(int userId);
        Task<CategoryResponseDto> CreateAsync(int userId, CreateCategoryDto dto);
        Task DeleteAsync(int userId, int categoryId);
    }
}