using FinanceAPI.DTOs;
using FinanceAPI.Models;
using FinanceAPI.Repositories;
using static FinanceAPI.DTOs.TransactionDtos;

namespace FinanceAPI.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TransactionResponseDto>> GetAllAsync(int userId)
        {
            var transactions = await _repository.GetAllByUserIdAsync(userId);
            return transactions.Select(t => new TransactionResponseDto
            {
                Id = t.Id,
                Description = t.Description,
                Amount = t.Amount,
                Type = t.Type.ToString(),
                Date = t.Date,
                CategoryName = t.Category.Name
            });
        }

        public async Task<TransactionResponseDto> CreateAsync(int userId, CreateTransactionDto dto)
        {
            var transaction = new Transaction
            {
                Description = dto.Description,
                Amount = dto.Amount,
                Type = dto.Type,
                Date = dto.Date,
                CategoryId = dto.CategoryId,
                UserId = userId
            };

            var created = await _repository.CreateAsync(transaction);
            var withCategory = await _repository.GetByIdAsync(created.Id);

            return new TransactionResponseDto
            {
                Id = withCategory!.Id,
                Description = withCategory.Description,
                Amount = withCategory.Amount,
                Type = withCategory.Type.ToString(),
                Date = withCategory.Date,
                CategoryName = withCategory.Category.Name
            };
        }

        public async Task DeleteAsync(int userId, int transactionId)
        {
            var transaction = await _repository.GetByIdAsync(transactionId);

            if (transaction == null || transaction.UserId != userId)
                throw new Exception("Transação não encontrada.");

            await _repository.DeleteAsync(transaction);
        }

        public async Task<SummaryDto> GetSummaryAsync(int userId)
        {
            var transactions = await _repository.GetAllByUserIdAsync(userId);

            var totalIncome = transactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);

            var totalExpense = transactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);

            return new SummaryDto
            {
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                Balance = totalIncome - totalExpense
            };
        }
    }
}