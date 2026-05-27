using FinanceAPI.Models;

namespace FinanceAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllByUserIdAsync(int userId);
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}