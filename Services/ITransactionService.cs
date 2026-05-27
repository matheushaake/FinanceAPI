using FinanceAPI.DTOs;
using static FinanceAPI.DTOs.TransactionDtos;

namespace FinanceAPI.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionResponseDto>> GetAllAsync(int userId);
        Task<TransactionResponseDto> CreateAsync(int userId, CreateTransactionDto dto);
        Task DeleteAsync(int userId, int transactionId);
    }
}