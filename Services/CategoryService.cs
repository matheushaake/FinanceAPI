using FinanceAPI.DTOs;
using FinanceAPI.Models;
using FinanceAPI.Repositories;

namespace FinanceAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync(int userId)
        {
            var categories = await _repository.GetAllByUserIdAsync(userId);
            return categories.Select(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Color = c.Color
            });
        }

        public async Task<CategoryResponseDto> CreateAsync(int userId, CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Color = dto.Color,
                UserId = userId
            };

            var created = await _repository.CreateAsync(category);

            return new CategoryResponseDto
            {
                Id = created.Id,
                Name = created.Name,
                Color = created.Color
            };
        }

        public async Task DeleteAsync(int userId, int categoryId)
        {
            var category = await _repository.GetByIdAsync(categoryId);

            if (category == null || category.UserId != userId)
                throw new Exception("Categoria não encontrada.");

            await _repository.DeleteAsync(category);
        }
    }
}